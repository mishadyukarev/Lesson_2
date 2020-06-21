using System;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

namespace Geekbrains
{
	public class Inventory : IInitialization
	{
		private Weapon[] _weapons;

		public Weapon[] Weapons => _weapons;

		public FlashLightModel FlashLight { get; private set; }

		public void OnStart()
		{
			_weapons = Main.Instance.Player.GetComponentsInChildren<Weapon>();

			foreach (var weapon in Weapons)
			{
				weapon.IsVisible = false;
			}
			Array.Resize(ref _weapons, 5);

			FlashLight = UnityEngine.Object.FindObjectOfType<FlashLightModel>();
		}

		//todo Добавить функционал
		public void AddWeapon(Weapon weapon)
		{
			int i = -1;
			bool b = true;
			foreach (var w in _weapons)
			{
				if (w && w.name == weapon.name) break;
				i++;
				if (w == null)
				{
					_weapons[i] = weapon;
					weapon.transform.SetParent(Camera.main.transform);
					weapon.transform.forward = _weapons[0].transform.forward;
					weapon.transform.position = _weapons[0].transform.position;
					weapon.IsVisible = false;
					b = false;
				}
				if (b == false) break;
			}

		}
        public void RemoveWeapon(Weapon weapon)
        {
            
        }
	}
}