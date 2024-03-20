using System;
using System.Diagnostics;
using Godot;

public partial class PlayerAnimationManager : AnimationTree
{
    private Vector2 _latestDirection = Vector2.Zero;
    private bool _isAttack = false;

    public override void _Ready()
    {
        Set("parameters/conditions/is_idle", true);
        Set("parameters/idle/blend_position", 1f);
    }

    public override void _Process(double delta)
    {
    }

    public void SetActive(bool value)
    {
        Active = value;
    }

    public void SetRunning(bool value)
    {
        Set("parameters/conditions/is_attack", !value);
        Set("parameters/conditions/is_idle", !value);
        Set("parameters/conditions/is_running", value);
    }

    public void SetAttack(bool value)
    {
        Set("parameters/conditions/is_attack", value);
        Set("parameters/conditions/is_idle", !value);
        Set("parameters/conditions/is_running", !value);
    }

    public void SetIdle(bool value)
    {
        Set("parameters/conditions/is_attack", !value);
        Set("parameters/conditions/is_idle", value);
        Set("parameters/conditions/is_running", !value);
    }

    public void HandleRotatePlayer(float direction)
    {
        if(direction == 0)
            return;
            
        Set("parameters/attack/blend_position", direction);
        Set("parameters/running/blend_position", direction);
        Set("parameters/idle/blend_position", direction);
    }
}



