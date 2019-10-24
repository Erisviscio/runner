using Assets.Game.Scripts.SO;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.SO
{
	[CreateAssetMenu(fileName = "LevelConfig", menuName = "Settings/Level", order = 1)]
	public class LevelConfig : ScriptableObject
	{
		public List<SpawnUnitConfig> enemies;
		public float spawnRate;
		public float increaseRatyBy;
		public int maxHealth;
	}
}