using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Misc;
using Assets.Game.Scripts.SO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Spawner
{
	public class Spawner : MonoBehaviour, IExecutable
	{
		[SerializeField] private List<Transform> spawnPoints;
		[SerializeField] private ObjectPoolContainer poolContainer;
		[SerializeField] private TimedExecution timer;

		private List<string> targetTags;
		private List<SpawnUnitConfig> targetConfigs;

		public void Setup(LevelConfig levelConfig)
		{
			targetConfigs = levelConfig.enemies;

			poolContainer.Init(targetConfigs);

			SetupTargetTags(targetConfigs);
			timer.StartTimer(levelConfig.spawnRate, levelConfig.increaseRatyBy);
		}

		public void Spawn()
		{
			string unitTag = GetRandomTag();
			GameObject item = poolContainer.Spawn(unitTag);
			item.transform.position = GetRandomSpawnPoint().position;

			// in more generic way it should be called via some kind of dictionary generated based on settings in SO, but in this project it`d add complexity.
			item.GetComponent<IPoolable>().Setup(targetConfigs.Single(unit => unit.Tag == unitTag));
		}

		public void Execute()
		{
			Spawn();
		}

		private Transform GetRandomSpawnPoint()
		{
			return spawnPoints[Random.Range(0, spawnPoints.Count)];
		}

		private string GetRandomTag()
		{
			return targetTags[Random.Range(0, targetTags.Count)];
		}

		private void SetupTargetTags(List<SpawnUnitConfig> targetConfigs)
		{
			targetTags = targetConfigs.Select(enemy => enemy.Tag).ToList();
		}
	}
}
