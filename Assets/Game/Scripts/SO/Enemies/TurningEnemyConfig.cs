using UnityEngine;

namespace Assets.Game.Scripts.SO
{
	[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Settings/Enemies/TurningEnemy", order = 1)]
	public class TurningEnemyConfig : SpawnUnitConfig
	{
		public float timeBetweenTurns;
		public float turnMagnitude;
		public float turnLength;
	}
}
