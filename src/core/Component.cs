using Godot;
using System.Collections.Generic;

public partial class Component : Node
{
    private Dictionary<string, Node> _states;

    public override void _Ready()
    {
        _states = new Dictionary<string, Node>();

        foreach (Node node in GetChildren())
        {
            if (node is Node n)
            {
                _states[node.Name.ToString().ToLower()] = n;
            }
        }
    }

    public Node FindComponent(string key)
    {
        foreach (KeyValuePair<string, Node> entry in _states)
        {
            if (entry.Key == key) return entry.Value;
        }

        return null;
    }
}
