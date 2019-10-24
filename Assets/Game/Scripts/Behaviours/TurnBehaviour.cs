using Assets.Game.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
	public class TurnBehaviour : MonoBehaviour
	{
		private float timeout;
		private float magnitude;
		private float length;
		private TurnFlag turnState;

		public void Init(float timeout, float magnitude, float length)
		{
			this.timeout = timeout;
			this.magnitude = magnitude;
			this.length = length;
		}

		private void OnEnable()
		{
			StartCoroutine(TurnCounter());
		}

		private IEnumerator TurnCounter()
		{
			// coroutines are stopped when parent object is disabled, so it`s ok.
			while (true)
			{
				yield return new WaitForSeconds(timeout);
				Turn();
			}
		}

		private IEnumerator TurnProcess(float magnitude, Vector3 direction, float length)
		{
			float timer = 0;
			while (timer < length)
			{
				transform.Translate(direction * magnitude * Time.deltaTime);
				yield return null;
				timer += Time.deltaTime;
			}

		}

		private void Turn()
		{
			Debug.Log("turn");
			Vector3 direction;
			if (turnState == TurnFlag.CanTurnLeft)
			{
				direction = Vector3.left;
				turnState = TurnFlag.CanTurnRight;
			}
			else
			{
				direction = Vector3.right;
				turnState = TurnFlag.CanTurnLeft;
			}
			StartCoroutine(TurnProcess(magnitude, direction, length));
		}
	}
}