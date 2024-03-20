using Godot;
using System;

public partial class EnemyDebug : Label
{
	[Export] 
	private FiniteStateMachine _fsm;
	[Export] 
	private Healthable _healthable;

	public override void _Process(double delta)
	{
		Text = 
		"Health: " + _healthable.GetHealth()
		;
	}
}
