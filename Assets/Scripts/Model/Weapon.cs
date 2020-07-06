using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
	public abstract class Weapon : BaseObjectScene, ISelectObj
	{
		private int _maxCountAmmunition = 40;
		private int _minCountAmmunition = 20;
		public Ammunition Ammunition;

		protected AmmunitionType[] _ammunitionType = {AmmunitionType.Bullet};

		[SerializeField] protected Transform _barrel;
		[SerializeField] protected float _force = 999;
		[SerializeField] protected float _rechergeTime = 0.001f;

		protected bool _isReady = true;
		protected Timer _timer = new Timer();

		public Clip Clip;
		private Clip[] _clips;
		private int _countClips = 3;
		private int _queueNow = 0;

		public int CountClip => _countClips;
		protected virtual void Start()
		{
			_clips = new Clip[_countClips];
			for(int i = 0; i < _countClips; i++)
			{
				_clips[i].CountAmmunition = UnityEngine.Random.Range(_minCountAmmunition, _maxCountAmmunition);
			}
			Clip = _clips[_queueNow];
		}

		public abstract void Fire();

		protected virtual void Update()
		{
			_timer.UpdateTimer();
			if (_timer.IsEvent())
			{
				ReadyShoot();
			}
		}
		abstract public string GetMessage();

		protected void ReadyShoot()
		{
			_isReady = true;
		}

		//protected void AddClip()
		//{

		//}

		public void ReloadClip()
		{
			if (Clip.CountAmmunition == 0) Array.Clear(_clips, _queueNow, 1);
			_queueNow++;
			if (_queueNow >= _countClips) _queueNow = 0;
			Clip = _clips[_queueNow];
		}

		public void TakeAway(int i = 1)
		{
			Clip.CountAmmunition -= i;
			_clips[_queueNow] = Clip;
		}
	}
}