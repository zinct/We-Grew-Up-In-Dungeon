using Godot;
using System;

public partial class WeaponAnimation : Node
{
	private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("../AnimationPlayer");
		_animationPlayer.Play("weapon/idle");
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
