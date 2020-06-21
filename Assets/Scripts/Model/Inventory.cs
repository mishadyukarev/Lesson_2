using System;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Geekbrains
{
	public class Inventory : IInitialization
	{
		private int _countWeapons = 5;
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
			Array.Resize(ref _weapons, _countWeapons);

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
					weapon.transform.forward = GameObject.FindWithTag("AppearWeapons").transform.forward;
					weapon.transform.position = GameObject.FindWithTag("AppearWeapons").transform.position;
					weapon.IsVisible = false;
					b = false;
				}
				if (b == false) break;
			}

		}
        public void RemoveWeapon(Weapon weapon)
        {
			weapon.transform.SetParent(GameObject.Find("Droped_Weapons").transform);
			int i = -1;
			foreach(var w in _weapons)
			{
				i++;
				if(weapon.name == w.name)
				{
					_weapons[i] = null;
					break;
				}
			}
		}
	}
}