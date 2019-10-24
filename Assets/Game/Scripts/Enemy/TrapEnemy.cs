using Assets.Game.Scripts.Actions;

namespace Assets.Game.Scripts.Enemy
{
	public class TrapEnemy : TurningEnemy
	{
		protected override void HandleActions()
		{
			damagingAction = new KillPlayerAction(healthService, clickedBehaviour);
			deathAction = new ActionOnNotify(passedFinishBehavior).SetAction(Die);
		}
	}
}
