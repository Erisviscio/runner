using Assets.Game.Scripts.Actions;
using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.SO;
using UnityEngine;

namespace Assets.Game.Scripts.Enemy
{
	public class TurningEnemy : BaseEnemy
	{
		[SerializeField] protected TurnBehaviour turnBehaviour;

		public override void Init(SpawnUnitConfig unitConfig)
		{
			base.Init(unitConfig);
			TurningEnemyConfig config = unitConfig as TurningEnemyConfig;
			turnBehaviour.Init(config.timeBetweenTurns, config.turnMagnitude, config.turnLength);
		}
		protected override void HandleActions()
		{
			base.HandleActions();
			damagingAction = new DamageAction(healthService, passedFinishBehavior);
			scoringAction = new ScoringAction(scoreService, clickedBehaviour);
		}
	}
}
