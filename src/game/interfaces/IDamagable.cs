using Godot;
using System;

public interface IDamagable
{
    [Signal]
	public delegate void DamageReceivedEventHandler();

	public void Hit(float damage);
}
