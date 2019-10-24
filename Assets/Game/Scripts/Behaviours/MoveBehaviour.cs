using UnityEngine;

namespace Assets.Game.Scripts.Behaviours
{
	public class MoveBehaviour : MonoBehaviour
	{
		private float speed;
		public void Init(float speed)
		{
			this.speed = speed;
		}

		private void Update()
		{
			this.transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
	}

}