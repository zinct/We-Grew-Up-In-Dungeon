using Godot;
using System;

public partial class PlayerAttackState : State
{
    public override void Ready()
    {
        Set("parameters/conditions/is_attack", true);
    }
}
