using Godot;
using System;

public interface IDamagable
{
    event EventHandler onDamageReceived;

    void Hit(float damage);
}
