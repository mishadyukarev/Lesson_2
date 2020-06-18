using UnityEngine;

namespace Geekbrains
{
	public class UiInterface
	{
		private FlashLightUiText _flashLightUiText;

		public FlashLightUiText LightUiText => _flashLightUiText ? _flashLightUiText :
			(_flashLightUiText = Object.FindObjectOfType<FlashLightUiText>());

		private FlashLightUiBar _flashLightUiBar;

		public FlashLightUiBar FlashLightUiBar
		{
			get
			{
				if (!_flashLightUiBar)
					_flashLightUiBar = Object.FindObjectOfType<FlashLightUiBar>();
				return _flashLightUiBar;
			}
		}

		private WeaponUiText _weaponUiText;

		public WeaponUiText WeaponUiText
		{
			get
			{
				if (!_weaponUiText)
					_weaponUiText = Object.FindObjectOfType<WeaponUiText>();
				return _weaponUiText;
			}
		}

		private SelectionObjMessageUi _selectionObjMessageUi;

		public SelectionObjMessageUi SelectionObjMessageUi
		{
			get
			{
				if (!_selectionObjMessageUi)
					_selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
				return _selectionObjMessageUi;
			}
		}
	}
}