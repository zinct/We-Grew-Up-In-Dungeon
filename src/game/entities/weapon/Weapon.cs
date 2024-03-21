using Godot;
using System;

public partial class DamageDea : Area2D
{
    [Export]
    public float attackDamage = 20;

    public void OnBodyEntered(Node2D body)
    {

    }
}
