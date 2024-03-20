using Godot;
using System;


public partial class PlayerIdleState : State
{
    private PlayerAnimationManager _animationManager;

    public override void Ready() 
    {
        _animationManager = (PlayerAnimationManager)GetTree().GetFirstNodeInGroup("PlayerAnimationTree");
        _animationManager.SetActive(true);
    }

    public override void Enter()
    {
        _animationManager.SetIdle(true);
    }

    public override void Update(double delta)
    {
        float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
        float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

        _animationManager.HandleRotatePlayer(horizontalDirection);

        bool isMoving = (Mathf.Abs(horizontalDirection) + Mathf.Abs(verticalDirection)) != 0f;

        if (isMoving)
            fsm.TransitionTo("running");

        if (Input.IsActionJustPressed("player_attack"))
            fsm.TransitionTo("attack");
    }

    public override void Exit() 
    {
        _animationManager.SetIdle(false);
    }
}
