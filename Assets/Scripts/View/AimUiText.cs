using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public class AimUiText : MonoBehaviour
	{
		private Aim[] _aims;
		private Text _text;
		private Button _button;
		private int _countPoint;
		private void Awake()
		{
			_aims = FindObjectsOfType<Aim>();
			_text = GetComponent<Text>();
		}

		private void OnEnable()
		{
			foreach (var aim in _aims)
			{
				aim.OnPointChange += UpdatePoint;
			}
			
			_button.onClick.AddListener(Call);
		}

		private void Call()
		{
			Debug.Log("Example");
		}

		private void OnDisable()
		{
			foreach (var aim in _aims)
			{
				aim.OnPointChange -= UpdatePoint;
			}
			
			_button.onClick.RemoveListener(Call);
		}

		private void UpdatePoint()
		{
			var pointTxt = "очков";
			++_countPoint;
			if (_countPoint >= 5) pointTxt = "очков";
			else if (_countPoint == 1) pointTxt = "очко";
			else if (_countPoint < 5) pointTxt = "очка";
			_text.text = $"Вы заработали {_countPoint} {pointTxt}";
		}
	}
}