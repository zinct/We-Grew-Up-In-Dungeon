using System.Diagnostics;
using Godot;

public partial class PlayerAnimation : Node
{
	private AnimationPlayer _animationPlayer;
	private CharacterBody2D _characterBody2D;
	private Vector2 _latestDirection = Vector2.Zero;
	
	private enum AnimationState { Running, Idle };

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("../AnimationPlayer");
		_characterBody2D = GetParent<CharacterBody2D>();
	}

	public override void _Process(double delta)
	{
		float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
		float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

		if(Input.IsKeyPressed(Key.P))
		{
			Debug.WriteLine("Key Pressed");
			_animationPlayer.Play("attack");
		}

		if(horizontalDirection != 0)
		{
			if(horizontalDirection > 0)
			{
				HandleRotatePlayer(Vector2.Right);
			}
			else
			{
				HandleRotatePlayer(Vector2.Left);
			}

			HandleAnimation(AnimationState.Running);
		}
		else if(verticalDirection != 0)
		{
			HandleAnimation(AnimationState.Running);
		}
		else
		{
			HandleAnimation(AnimationState.Idle);
		}
	}

	private void HandleAnimation(AnimationState state)
	{
		if(_animationPlayer.CurrentAnimation == "attack") return;
		if(state == AnimationState.Running)
		{
			if(_animationPlayer.CurrentAnimation != "running")
			{
				_animationPlayer.Play("running");
			}
		}
		else
		{
			if(_animationPlayer.CurrentAnimation != "idle")
			{
				_animationPlayer.Play("idle");
			}
		}
	}

	private void HandleRotatePlayer(Vector2 direction)
	{
		if(direction == Vector2.Right)
		{
			_characterBody2D.Scale = new Vector2(_characterBody2D.Scale.X, _characterBody2D.Scale.X);
			_characterBody2D.RotationDegrees = 0f;
		}
		else if(direction == Vector2.Left)
		{
			_characterBody2D.Scale = new Vector2(_characterBody2D.Scale.X, Mathf.Abs( _characterBody2D.Scale.Y)  * -1);
			_characterBody2D.RotationDegrees = 180f;
		}
	}
}



