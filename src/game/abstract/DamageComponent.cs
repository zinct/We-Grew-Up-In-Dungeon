using Godot;
using System;

public partial class DamageComponent : Node
{
    [Export]
    private HealthComponent _healthComponent;

    [Signal]
    public delegate void DamageReceivedEventHandler();

    public void Hit(float damage)
    {
        EmitSignal(SignalName.DamageReceived);
        _healthComponent.Health -= damage;
    }
}
