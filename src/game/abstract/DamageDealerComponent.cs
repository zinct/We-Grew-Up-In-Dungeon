using Godot;
using System;

public partial class DamageDealerComponent : Area2D
{
    [Export]
    public float attackDamage = 0f;

    public override void _Ready()
    {

    }
}
