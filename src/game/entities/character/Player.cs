using Godot;
using System;

public partial class Player : Node, IHealthable
{
    public float health { get => health; set => health = value; }
}
