using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Actions
{
	public class ScoringAction : ActionOnNotify
	{
		private IScoreService scoreService;
		public ScoringAction(IScoreService scoreService, List<IRaisableBehaviour> sources) : base(sources)
		{
			this.scoreService = scoreService;
			action = () => { scoreService.IncreaseScore(); };
			SetAction(action);
		}

		public ScoringAction(IScoreService scoreService, IRaisableBehaviour source) : base(source)
		{
			this.scoreService = scoreService;
			action = () => { scoreService.IncreaseScore(); };
			SetAction(action);
		}
	}
}
