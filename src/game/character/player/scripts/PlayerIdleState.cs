using Godot;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;

public partial class PlayerIdleState : State
{
    public override void Enter() { }
    public override void Exit() { }
    public override void Ready() { }

    public override void Update(double delta)
    {
        float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
        float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

        bool isMoving = (Mathf.Abs(horizontalDirection) + Mathf.Abs(verticalDirection)) != 0f;

        if (isMoving)
            fsm.TransitionTo("running");

        if (Input.IsActionJustPressed("player_attack"))
        {
            fsm.TransitionTo("attack");
        }

    }
}
