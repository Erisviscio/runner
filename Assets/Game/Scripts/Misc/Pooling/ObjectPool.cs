
using Assets.Game.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Misc
{
	public class ObjectPool
	{
		private string tag;
		private GameObject poolablePrefab;
		private Queue<GameObject> objects;

		public ObjectPool(string tag, GameObject prefab, int defaultSize)
		{
			this.tag = tag;
			this.poolablePrefab = prefab;
			this.objects = new Queue<GameObject>();

			AddNewItems(defaultSize);
		}

		public GameObject Spawn()
		{
			if (objects.Count <= 0)
			{
				AddNewItems();
			}

			GameObject result = objects.Dequeue();
			result.GetComponent<IPoolable>().OnReturnToPool += ReturnObjectToPool;
			result.SetActive(true);
			return result;
		}

		private void ReturnObjectToPool(object sender, GameObject targetObject)
		{
			IPoolable currentPoolable = sender as IPoolable;
			if (currentPoolable != null)
			{
				currentPoolable.OnReturnToPool -= ReturnObjectToPool;
			}

			targetObject.SetActive(false);
			objects.Enqueue(targetObject);
		}

		private void AddNewItems(int count = 1)
		{
			GameObject currentItem;
			for (int i = 0; i < count; i++)
			{
				currentItem = GameObject.Instantiate(poolablePrefab);
				currentItem.SetActive(false);

				objects.Enqueue(currentItem);
			}
		}
	}
}
