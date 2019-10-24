using Assets.Game.Scripts.Interfaces.Services;
using System;
using UnityEngine;

public class HealthService : IHealthService
{
	private int health;
	public int CurrentHealth
	{
		get => health;
		private set { health = value; OnHealthChanged.Invoke(this, value); }
	}

	public event EventHandler OnPlayerDied;
	public event EventHandler<int> OnHealthChanged;

	public void Setup(int maxHealth)
	{
		CurrentHealth = maxHealth;
	}

	public void DealDamage(int damage = 1)
	{
		if (CurrentHealth > damage)
		{
			CurrentHealth -= damage;
		} else
		{
			CurrentHealth = 0;
			OnPlayerDied?.Invoke(this, EventArgs.Empty);
		}
		Debug.Log($"{damage} damage dealt. Current health : {CurrentHealth}");
	}

	public void KillPlayer()
	{
		CurrentHealth = 0;
		OnPlayerDied?.Invoke(this, EventArgs.Empty);
	}
}
