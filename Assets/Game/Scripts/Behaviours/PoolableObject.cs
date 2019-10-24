using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.SO;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
	class PoolableObject : MonoBehaviour, IPoolable
	{
		public string Tag => enemyTag;
		private string enemyTag;

		public event EventHandler<GameObject> OnReturnToPool;
		private ISpawnedUnit targetUnit;

		private void Awake()
		{
			targetUnit = GetComponent<ISpawnedUnit>();
			if (targetUnit == null)
			{
				Debug.LogError("Poolable object could must have ISpawnedUnit to work correctly");
			}
		}

		private void OnEnable()
		{
			targetUnit.OnUnitDied += HandleUnitDeath;
		}

		private void OnDisable()
		{
			targetUnit.OnUnitDied -= HandleUnitDeath;
		}

		private void HandleUnitDeath(object sender, EventArgs e)
		{
			ReturnToPool();
		}

		public void Setup(SpawnUnitConfig unitConfig)
		{
			targetUnit.Init(unitConfig);
		}

		public void ReturnToPool()
		{
			OnReturnToPool?.Invoke(this, this.gameObject);
		}
	}
}
