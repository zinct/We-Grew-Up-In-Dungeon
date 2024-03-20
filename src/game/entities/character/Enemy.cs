using Godot;
using System;

public partial class Enemy : Node, IHealthable, IDamagable
{
    [Export]
    public Label label;

    [Export]
    public float health { get; private set; } = 0f;

    public void Hit(float damage)
    {
        throw new NotImplementedException();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		label.Text = 
		"Health: " + health
		;
	}
}
