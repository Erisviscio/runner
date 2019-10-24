using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Misc;
using System;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
	public class PassedFinishBehavior : MonoBehaviour, IRaisableBehaviour
	{
		public event Action OnRaised;

		void OnTriggerEnter(Collider other)
		{
			//todo: get static const file
			if (other.tag == TagContainer.FinishTriggerTag)
			{
				OnRaised?.Invoke();
			}
		}
	}
}
