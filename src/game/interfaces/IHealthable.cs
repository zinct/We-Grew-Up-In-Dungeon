using Godot;
using System;

public interface IHealthable
{
	float health { get;}

	[Signal]
	public delegate void HealthDepletedEventHandler();
}
