using Godot;
using System;

public partial class EnemyHitState : State
{
    public void OnDamageableDamageReceived()
    {
        GD.Print("HEHE");
    }
}
