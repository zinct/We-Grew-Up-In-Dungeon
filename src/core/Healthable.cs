using Godot;
using System;

public partial class Healthable : Node
{
	[Export]
	private float health = 100f;

	[Signal]
	public delegate void HealthDepletedEventHandler();

	public float GetHealth()
	{
		return health;
	} 

	public void SetHealth(float amount)
	{
		health = amount;

		if(health <= 0)
			health = 0;
	} 
}
