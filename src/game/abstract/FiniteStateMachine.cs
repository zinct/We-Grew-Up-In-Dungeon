using System;
using Godot;
using Godot.Collections;

public partial class FiniteStateMachine : Node
{
    [Export]
    public NodePath initialState;

    private State _currentState;
    private Dictionary<string, State> _states;

    public override void _Ready()
    {
        _states = new Dictionary<string, State>();

        foreach (Node node in GetChildren())
        {
            if (node is State s)
            {
                _states[node.Name] = s;
                s.fsm = this;
                s.Ready();
                s.Exit();
            }
        }

        if(_currentState != null)
        {
            _currentState = GetNode<State>(initialState);
            _currentState.Enter();
        }
    }

    public void TransitionTo(String key)
    {
        if (!_states.ContainsKey(key) || _currentState == _states[key])
            return;

        _currentState.Exit();
        _currentState = _states[key];
        _currentState.Enter();
    }

    public override void _Process(double delta)
    {
        if(_currentState != null)
            _currentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        if(_currentState != null)
            _currentState.PhysicsUpdate(delta);
    }
    public override void _UnhandledInput(InputEvent @event)
    {
        if(_currentState != null)
            _currentState._UnhandledInput(@event);
    }

}
