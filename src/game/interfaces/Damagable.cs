using Godot;
using System;

public interface IDamagable
{
    [Signal]
    delegate void DamageReceivedEventHandler();

    void Hit(float damage);
}
