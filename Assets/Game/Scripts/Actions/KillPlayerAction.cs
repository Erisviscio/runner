using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Actions
{
	public class KillPlayerAction : ActionOnNotify
	{
		private IHealthService healthService;
		public KillPlayerAction(IHealthService healthService, List<IRaisableBehaviour> sources) : base(sources)
		{
			this.healthService = healthService;
			action = () => { healthService.KillPlayer(); };
			SetAction(action);
		}

		public KillPlayerAction(IHealthService healthService, IRaisableBehaviour source) : base(source)
		{
			this.healthService = healthService;
			action = () => { healthService.KillPlayer(); };
			SetAction(action);
		}
	}
}
