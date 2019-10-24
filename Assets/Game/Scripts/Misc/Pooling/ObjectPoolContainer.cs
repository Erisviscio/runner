using Assets.Game.Scripts.Misc;
using Assets.Game.Scripts.SO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Misc
{
	public class ObjectPoolContainer : MonoBehaviour
	{
		private List<SpawnUnitConfig> unitsConfig;

		private Dictionary<string, ObjectPool> pools;
		public void Init(List<SpawnUnitConfig> unitsConfig)
		{
			this.unitsConfig = unitsConfig;
			CreatePools();
		}

		public GameObject Spawn(string tag)
		{
			return pools[tag].Spawn();
		}

		public List<string> GetPoolTags()
		{
			return pools.Keys.ToList();
		}

		private void CreatePools()
		{
			pools = new Dictionary<string, ObjectPool>();

			foreach (var item in unitsConfig)
			{
				pools.Add(item.Tag, new ObjectPool(item.Tag, item.Prefab, item.DefaultPoolSize));
			}
		}
	}

}
