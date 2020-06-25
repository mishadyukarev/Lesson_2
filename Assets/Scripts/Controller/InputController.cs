using UnityEngine;

namespace Geekbrains
{
	public class InputController : BaseController, IOnUpdate
	{

		private KeyCode _activeFlashLight = KeyCode.L;
		private KeyCode _cancel = KeyCode.Escape;

		private int _mouseButton = (int)MouseButton.LeftButton;

		public InputController()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		
		public void OnUpdate()
		{
			if (Input.GetKeyDown(_activeFlashLight))
			{
				Main.Instance.FlashLightController.Switch();
			}

			if (Input.GetKeyDown(KeyCode.F))//подбор оружия
			{
				Main.Instance.SelectionController._isKey = true;
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Main.Instance.WeaponController.SelectWeapon(0);
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Main.Instance.WeaponController.SelectWeapon(1);
			}

			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				Main.Instance.WeaponController.SelectWeapon(2);
			}

			if (Input.GetKeyDown(KeyCode.G))
			{
				Main.Instance.WeaponController.RemoveWeapon();
			}

			if (Input.GetKeyDown(KeyCode.R))
			{
				Main.Instance.WeaponController.ReloadClip();
			}


			if (Main.Instance.WeaponController.IsActive == true && Input.GetMouseButton(_mouseButton))
			{
				Main.Instance.WeaponController.Fire();
			}



			if (Input.GetKeyDown(_cancel))
			{
				Main.Instance.WeaponController.Off(false);
				Main.Instance.FlashLightController.Off(false);
			}
		}
	}
}