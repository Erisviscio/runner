using System;
using System.Collections.Generic;
using Assets.Game.Scripts.Actions;
using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Interfaces.Services;
using Assets.Game.Scripts.SO;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Enemy
{
	public class BaseEnemy : MonoBehaviour, ISpawnedUnit
	{
		[SerializeField] protected ClickedBehaviour clickedBehaviour;
		[SerializeField] protected MoveBehaviour moveBehaviour;
		[SerializeField] protected PassedFinishBehavior passedFinishBehavior;

		public event EventHandler OnUnitDied;

		protected IHealthService healthService;
		protected IScoreService scoreService;

		protected ActionOnNotify damagingAction;
		protected ActionOnNotify deathAction;
		protected ActionOnNotify scoringAction;

		public virtual void Init(SpawnUnitConfig unitConfig)
		{
			HandleActions();
			moveBehaviour.Init(unitConfig.Speed);
		}

		[Inject]
		protected virtual void ResolveServices(IHealthService healthService, IScoreService scoreService)
		{
			this.scoreService = scoreService;
			this.healthService = healthService;
		}

		protected virtual void HandleActions()
		{
			deathAction = new ActionOnNotify(new List<IRaisableBehaviour> { passedFinishBehavior, clickedBehaviour }).SetAction(Die);
		}

		protected void Die()
		{
			// if there is some timeout or animations
			OnUnitDied?.Invoke(this, EventArgs.Empty);
		}

		private void UnsubscribeActions()
		{
			damagingAction?.Reset();
			deathAction?.Reset();
			scoringAction?.Reset();
		}

		private void OnDisable()
		{
			UnsubscribeActions();
		}
	}
}
