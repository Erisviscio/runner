using Assets.Game.Scripts.SO;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Interfaces
{
	public interface IPoolable
	{
		event EventHandler<GameObject> OnReturnToPool;
		string Tag { get; }

		void Setup(SpawnUnitConfig enemyConfig);
	}
}
