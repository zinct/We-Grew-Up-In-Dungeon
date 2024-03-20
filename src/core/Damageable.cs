using Godot;
using System;

public partial class Damageable : Node
{
	[Export]
	private Healthable _healthable;

	[Signal]
	public delegate void DamageReceivedEventHandler();

	public void Hit(float damage)
	{
		EmitSignal(SignalName.DamageReceived);

		_healthable.SetHealth(_healthable.GetHealth() - damage);

		if(_healthable.GetHealth() <= 0)
			_healthable.EmitSignal(Healthable.SignalName.HealthDepleted);
	}
}
