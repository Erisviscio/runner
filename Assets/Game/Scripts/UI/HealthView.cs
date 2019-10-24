using Assets.Game.Scripts.Interfaces.Services;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
	//its probably redundant right now, but i believe there is always specific view logics for this type of things coming.
	class HealthView : MonoBehaviour
	{
		[SerializeField] private FormatedText textComponent;
		private IHealthService healthService;

		private void ChangeHealth(int newValue)
		{
			textComponent.Text = newValue.ToString();
		}

		public void Init(IHealthService healthService)
		{
			this.healthService = healthService;
			healthService.OnHealthChanged += HealthChangedHandler;
		}

		private void HealthChangedHandler(object sender, int newValue)
		{
			ChangeHealth(newValue);
		}

		private void OnDisable()
		{
			healthService.OnHealthChanged -= HealthChangedHandler;
		}
	}
}
