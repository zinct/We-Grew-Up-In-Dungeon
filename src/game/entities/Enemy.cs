using Godot;
using System;

public partial class Enemy : CharacterBody2D, IDamagable, IHealthable
{
    [Export]
    private float _health;
    public float Health 
    { 
        get => _health; 
        set
        {
            if(_health - value <= 0)
            {
                _health = 0;
                onHealthDepleted(this, EventArgs.Empty);
            }
            else _health = value;
        }
    }

    public event EventHandler onDamageReceived;
    public event EventHandler onHealthDepleted;

    public override void _Ready()
    {
    }

    public void Test()
    {
        GD.Print("Tes");
    }

    public void Hit(float damage)
    {
        Health -= damage;
    }
}
