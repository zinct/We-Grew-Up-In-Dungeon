using Godot;
using System;

public partial class EnemyIdleState : State
{
	private void OnArea2DAreaEntered(Area2D area)
	{
		GD.Print("OK");
	}
}
