using Assets.Game.Scripts.Behaviours;
using Assets.Game.Scripts.Interfaces.Services;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.UI
{
	public class GameUIFacade : MoveBehaviour
	{
		[SerializeField] private HealthView health;
		[SerializeField] private ScoreView score;
		[SerializeField] private GameOverView gameOverScreen;

		private IScoreService scoreService;
		private IHealthService healthService;

		[Inject]
		public void Init(IScoreService scoreService, IHealthService healthService)
		{
			this.scoreService = scoreService;
			this.healthService = healthService;
			HandleSubscriptions();
		}

		private void HandleSubscriptions()
		{
			health.Init(healthService);
			score.Init(scoreService);
			gameOverScreen.Init(healthService, scoreService);
		}
	}
}
