using System;

namespace Assets.Game.Scripts.Interfaces.Services
{
	public interface IScoreService
	{
		int Score { get; }

		event EventHandler<int> OnScoreChanged;

		void IncreaseScore(int damage = 1);

		int GetScore();
	}
}
