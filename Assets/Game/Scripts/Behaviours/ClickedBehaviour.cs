using Assets.Game.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Game.Scripts.Behaviours
{
	public class ClickedBehaviour : MonoBehaviour, IPointerClickHandler, IRaisableBehaviour
	{
		public event Action OnRaised;

		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log("clicked");
			OnRaised.Invoke();
		}
	}
}