
namespace Geekbrains
{
	public sealed class Gun : Weapon
	{
		public override string GetMessage()
		{
			return this.name;
		}
		public override void Fire()
		{
			if (!_isReady) return;
			if (Clip.CountAmmunition <= 0) return;
			var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);//todo Pool object
			temAmmunition.AddForce(_barrel.forward * _force);
			TakeAway();
			_isReady = false;
			//Invoke(nameof(ReadyShoot), _rechergeTime);
			_timer.StartTimer(_rechergeTime);
		}
	}
}