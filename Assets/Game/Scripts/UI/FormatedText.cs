using TMPro;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
	public class FormatedText : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI targetTMP;
		[SerializeField] private string format;

		public string Text
		{
			get { return targetTMP.text; }
			set { targetTMP.text = string.Format(format, value); }
		}
	}
}