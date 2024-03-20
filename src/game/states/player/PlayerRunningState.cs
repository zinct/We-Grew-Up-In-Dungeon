using Godot;
using System;
using System.Diagnostics;

public partial class PlayerRunningState : State
{
    [Export]
    public const float Speed = 300.0f;
    private CharacterBody2D _characterBody2D;    
    private PlayerAnimationManager _animationManager;
    private float _previousDirection;

    public override void Ready()
    {
        _characterBody2D = (CharacterBody2D)GetTree().GetFirstNodeInGroup("PlayerCharacterBody2D");
        _animationManager = (PlayerAnimationManager)GetTree().GetFirstNodeInGroup("PlayerAnimationTree");
    }

    public override void Enter()
    {
        _animationManager.SetRunning(true);
    }

    public override void Update(double delta)
    {
        float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
        float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

        _animationManager.HandleRotatePlayer(horizontalDirection);

        bool isMoving = (Mathf.Abs(horizontalDirection) + Mathf.Abs(verticalDirection)) == 0f;

        if (Input.IsActionJustPressed("player_attack"))
            fsm.TransitionTo("attack");

        if (isMoving)
            fsm.TransitionTo("idle", _previousDirection);
    }

    public override void PhysicsUpdate(double delta)
    {
        Vector2 velocity = _characterBody2D.Velocity;

        float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
        float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

        if(horizontalDirection != 0)
            _previousDirection = horizontalDirection;

        if (horizontalDirection != 0)
            velocity.X = horizontalDirection * Speed;
        else
            velocity.X = Mathf.MoveToward(velocity.X, 0, 50);

        if (verticalDirection != 0)
            velocity.Y = verticalDirection * Speed;
        else
            velocity.Y = Mathf.MoveToward(velocity.Y, 0, 50);

        if (horizontalDirection != 0 || verticalDirection != 0)
            velocity = velocity.Normalized() * Speed;

        _characterBody2D.Velocity = velocity;
        _characterBody2D.MoveAndSlide();
    }

    public override void Exit() 
    {
        _animationManager.SetRunning(false);
    }
}
