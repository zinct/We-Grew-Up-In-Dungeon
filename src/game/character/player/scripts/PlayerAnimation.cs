using System;
using System.Diagnostics;
using Godot;

public partial class PlayerAnimation : AnimationTree
{
	private CharacterBody2D _characterBody2D;
	private Vector2 _latestDirection = Vector2.Zero;
	private bool _isAttack = false;
	
	public override void _Ready()
	{
		Set("parameters/conditions/is_idle", true);
		Set("parameters/idle/blend_position", 1f);

		_characterBody2D = GetParent<CharacterBody2D>();
	}

	public override void _Process(double delta)
	{
		float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
		float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

		if(Input.IsActionJustPressed("player_attack"))
		{
			SetAttack(true);
		}
		
		if(horizontalDirection != 0)
		{
			HandleRotatePlayer(horizontalDirection);
			SetRunning(true);
		}
		else if(verticalDirection != 0)
		{
			SetRunning(true);
		}
		else
		{
			SetIdle(true);
		}

	}

	private void SetRunning(bool value)
	{
		Set("parameters/conditions/is_running", value);
		Set("parameters/conditions/is_idle", !value);
	}

	public void SetAttack(bool value)
	{
		Debug.WriteLine(_isAttack);
		if(_isAttack && value) return;
		_isAttack = value;
		Set("parameters/conditions/is_attack", value);
		Set("parameters/conditions/is_idle", false);
		Set("parameters/conditions/is_running", false);
	}

	private void SetIdle(bool value)
	{
		Set("parameters/conditions/is_running", !value);
		Set("parameters/conditions/is_idle", value);
	}

	private void HandleRotatePlayer(float direction)
	{
		Set("parameters/attack/blend_position", direction);
		Set("parameters/running/blend_position", direction);
		Set("parameters/idle/blend_position", direction);
	}
}



