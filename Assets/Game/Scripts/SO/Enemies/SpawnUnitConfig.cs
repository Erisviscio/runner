using UnityEngine;

namespace Assets.Game.Scripts.SO
{
	[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Settings/Enemies/DefaultEnemy", order = 1)]
	public class SpawnUnitConfig : ScriptableObject
	{
		public string Tag;
		public float Speed;
		public int DefaultPoolSize;
		public GameObject Prefab;
	}
}
