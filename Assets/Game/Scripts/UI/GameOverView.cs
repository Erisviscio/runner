using Assets.Game.Scripts.Interfaces.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
	class GameOverView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI viewTitle;
		[SerializeField] private FormatedText scoreValue;
		[SerializeField] private Button playAgainButton;
		[Space()]
		[SerializeField] private string message;
		public string MessageOnLose
		{
			get => message;
			set { message = value; }
		}

		private IHealthService healthService;
		private IScoreService scoreService;

		private void Awake()
		{
			playAgainButton.onClick.AddListener(StartNewGame);
		}

		public void Init(IHealthService healthService, IScoreService scoreService)
		{
			this.healthService = healthService;
			this.scoreService = scoreService;

			this.healthService.OnPlayerDied += PlayerDiedHandler ;
		}

		private void PlayerDiedHandler(object sender, System.EventArgs args)
		{
			gameObject.SetActive(true);
			UpdateValues(MessageOnLose, scoreService.Score);
		}

		private void UpdateValues(string message, int score)
		{
			viewTitle.text = message;
			scoreValue.Text = score.ToString();
		}

		private void StartNewGame()
		{
			gameObject.SetActive(false);
			SceneManager.LoadScene(0);
		}
	}
}
