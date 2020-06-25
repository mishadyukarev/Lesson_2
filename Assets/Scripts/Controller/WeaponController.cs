using UnityEngine;

namespace Geekbrains
{
	public class WeaponController : BaseController, IOnUpdate
	{
		private Weapon _weapon;

		public void OnUpdate()
		{

		}

		public override void On(BaseObjectScene weapon)
		{
			if (IsActive) return;
			base.On(weapon);

			_weapon = weapon as Weapon;
			if (_weapon == null) return;
			_weapon.IsVisible = true;
			UiInterface.WeaponUiText.SetActive(true);
			UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		public override void Off(bool b)//b - для обработки видимости (когда оружие выбрасываем)
		{
			if (!IsActive) return;
			base.Off(b);
			_weapon.IsVisible = b;
			_weapon = null;
			UiInterface.WeaponUiText.SetActive(false);
		}

		public void ReloadClip()
		{
			if (_weapon == null) return;
			_weapon.ReloadClip();
			UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		public void RemoveWeapon()
		{
			if (_weapon)
			{
				Main.Instance.Inventory.RemoveWeapon(_weapon);
				Off(true);
			}
		}

		public void Fire()
		{
			if (!IsActive) return;
			_weapon.Fire();
			UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
		}

		/// <summary>
		/// Выбор оружия
		/// </summary>
		/// <param name="i">Номер оружия</param>
		public void SelectWeapon(int i)
		{
			Main.Instance.WeaponController.Off(true);
			var tempWeapon = Main.Instance.Inventory.Weapons[i]; // инкапсулировать
			if (tempWeapon != null)
			{
				Main.Instance.WeaponController.On(tempWeapon);
			}
		}
	}
}