using System;


namespace Assets.Game.Scripts.Interfaces.Services
{
	public interface IHealthService
	{
		int CurrentHealth { get;}

		event EventHandler OnPlayerDied;
		event EventHandler<int> OnHealthChanged;

		void Setup(int maxHealth);

		void DealDamage(int damage = 1);

		void KillPlayer();
	}
}
