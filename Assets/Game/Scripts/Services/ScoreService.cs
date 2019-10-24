using Assets.Game.Scripts.Interfaces.Services;
using System;
using UnityEngine;

public class ScoreService : IScoreService
{
	public int Score { get; private set; }

	public event EventHandler<int> OnScoreChanged;

	private void Awake()
	{
		Score = 0;
	}

	public void IncreaseScore(int damage = 1)
	{
		Score += damage;
		OnScoreChanged?.Invoke(this, Score);

	}

	public int GetScore()
	{
		throw new NotImplementedException();
	}
}
