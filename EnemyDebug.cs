using Godot;
using System;
using System.Text.Encodings.Web;

public partial class EnemyDebug : Label
{
    [Export]
    private CharacterBody2D _enemy;
    private Enemy s;

    public override void _Ready()
    {
        s = (Enemy)_enemy;
        GD.Print("BITCH");
    }

    public override void _Process(double delta)
    {
        
        Text = "Health: s" + s.Health;
    }
}
