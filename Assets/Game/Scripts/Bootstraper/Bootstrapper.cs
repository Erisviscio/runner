using Assets.Game.Scripts.Interfaces.Services;
using Assets.Game.Scripts.SO;
using Assets.Game.Scripts.Spawner;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
	[SerializeField] private LevelConfig levelConfiguration;
	[SerializeField] private Spawner spawner;

	private IHealthService healthService;
	private IScoreService scoreService;

	[Inject]
	private void Init(IHealthService healthService, IScoreService scoreService)
	{
		this.scoreService = scoreService;
		this.healthService = healthService;

		healthService.Setup(levelConfiguration.maxHealth);
	}

	private void Start()
	{
		spawner.Setup(levelConfiguration);
	}
}
