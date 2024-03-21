using Godot;
using System;

public partial class Weapon : Area2D
{
    [Export]
    public float attackDamage = 20;

    public void OnBodyEntered(Node2D body)
    {
        if(body is IDamagable damagable)
            damagable.Hit(attackDamage);
    }
}
