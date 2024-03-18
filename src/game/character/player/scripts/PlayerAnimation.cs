using System.Diagnostics;
using Godot;

public partial class PlayerAnimation : AnimationTree
{
	private CharacterBody2D _characterBody2D;
	private Vector2 _latestDirection = Vector2.Zero;
	
	public override void _Ready()
	{
		Set("parameters/conditions/is_idle", true);
		_characterBody2D = GetParent<CharacterBody2D>();
	}

	public override void _Process(double delta)
	{
		float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
		float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

		if(Input.IsKeyPressed(Key.P))
			SetAttack(true);

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
		Set("parameters/conditions/is_attack", value);
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



