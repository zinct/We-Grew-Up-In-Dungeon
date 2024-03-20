using System;
using System.Diagnostics;
using Godot;
using Godot.Collections;

public partial class FiniteStateMachine : Node
{
	[Export]
	public NodePath initialState;

	[Signal]
	public delegate void TransitionChangedEventHandler(State previousState, State nextState);

	// Private
	public State _currentState;
	public State previousState;
	private Dictionary<string, State> _states;

	public override void _Ready()
	{
		_states = new Dictionary<string, State>();

		foreach (Node node in GetChildren())
		{
			if (node is State s)
			{
				_states[node.Name.ToString().ToLower()] = s;
				s.fsm = this;
				s.Ready();
				s.Exit();
			}
		}

		_currentState = GetNode<State>(initialState);
		_currentState.Enter();
	}

	public void TransitionTo(String key, dynamic args = null)
	{
		previousState = _currentState;
		if (!_states.ContainsKey(key) || _currentState == _states[key])
			return;

		_currentState.Exit();
		_currentState = _states[key];
		_currentState.Enter();

		// Emit Signal
		EmitSignal(SignalName.TransitionChanged, previousState, _currentState);
	}

	public override void _Process(double delta)
	{
		_currentState?.Update(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		_currentState?.PhysicsUpdate(delta);
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		_currentState?.UnhandledInput(@event);
	}
}






