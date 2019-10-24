using Assets.Game.Scripts.Interfaces.Services;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
	//its probably redundant right now, but i believe there is always specific view logics for this type of things coming.
	class ScoreView : MonoBehaviour
	{
		[SerializeField] private FormatedText textComponent;

		private IScoreService scoreService;

		private void ChangeScore(int newValue)
		{
			textComponent.Text = newValue.ToString();
		}

		public void Init(IScoreService scoreService)
		{
			this.scoreService = scoreService;
			this.scoreService.OnScoreChanged += ScoreChangedHandler;
		}

		private void ScoreChangedHandler(object sender, int newValue)
		{
			ChangeScore(newValue);
		}

		private void OnDisable()
		{
			this.scoreService.OnScoreChanged -= ScoreChangedHandler;
		}
	}
}
