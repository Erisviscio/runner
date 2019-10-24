using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Actions
{
	public class DamageAction : ActionOnNotify
	{
		private IHealthService healthService;
		public DamageAction(IHealthService healthService, List<IRaisableBehaviour> sources) : base(sources)
		{
			this.healthService = healthService;
			action = () => { healthService.DealDamage(); };
			SetAction(action);
		}

		public DamageAction(IHealthService healthService, IRaisableBehaviour source, int damageDealt = 1) : base(source)
		{
			this.healthService = healthService;
			action = () => { healthService.DealDamage(damageDealt); };
			SetAction(action);
		}
	}
}
