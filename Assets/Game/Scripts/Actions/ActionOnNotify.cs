using Assets.Game.Scripts.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Actions
{
	public class ActionOnNotify
	{
		protected Action action;
		protected List<IRaisableBehaviour> sources = new List<IRaisableBehaviour>();

		public ActionOnNotify(IRaisableBehaviour newSource)
		{
			this.sources.Add(newSource);
		}

		public ActionOnNotify(List<IRaisableBehaviour> newSource)
		{
			this.sources.AddRange(newSource);
		}

		public ActionOnNotify SetAction(Action action)
		{
			this.action = action;

			sources.ForEach(source => source.OnRaised += this.action);
			return this;
		}

		public void Reset()
		{
			sources.ForEach(source => source.OnRaised -= action);
		}
	}
}
