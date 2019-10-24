using Assets.Game.Scripts.Actions;
using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.Enemy
{
	public class DefaultEnemy : BaseEnemy, ISpawnedUnit
	{
		protected override void HandleActions()
		{
			base.HandleActions();
			damagingAction = new DamageAction(healthService, passedFinishBehavior);
			scoringAction = new ScoringAction(scoreService, clickedBehaviour);
		}
	}
}
