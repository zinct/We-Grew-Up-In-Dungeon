using Godot;
using System;

public partial class Weapon : Area2D
{
	[Export]
	public float attackDamage = 20;

    public void OnBodyEntered(Node2D body)
	{
		GD.Print(body);
		if(body is IDamagable IDamagable) {
		GD.Print("ok");

		}
		// foreach (Node node in body.GetChildren())
		// {
		// 	if (node is IDamagable damageable)
		// 		damageable.Hit(attackDamage);
		// }
		
	}
}
