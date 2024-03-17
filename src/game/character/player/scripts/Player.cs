using Godot;
using System;
using System.Diagnostics;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
		float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

		if(horizontalDirection != 0)
		{
			velocity.X = horizontalDirection * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, 50);
		}

		if(verticalDirection != 0)
		{
			velocity.Y = verticalDirection * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(velocity.Y, 0, 50);
		}

		if(horizontalDirection != 0 || verticalDirection != 0)
		{
			velocity = velocity.Normalized() * Speed;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
