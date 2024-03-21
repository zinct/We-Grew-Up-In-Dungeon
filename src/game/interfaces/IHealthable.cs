using Godot;
using System;

public interface IHealthable
{
	float Health { get; set; }

	event EventHandler onHealthDepleted;
}
