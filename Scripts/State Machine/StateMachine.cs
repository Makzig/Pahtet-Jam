using Godot;
using System;

public partial class StateMachine : Node
{

	[Export]
	State InitionState;
	[Signal]
	public delegate void TransitedEventHandler(string stateName);



	public override void _Ready()
	{
		foreach (State state in GetChildren())
        {
			state.StateMachine = this;
        }
		InitionState.EnterState();
	}

	

	public override void _Process(double delta)
	{
		InitionState.Update(delta);
	}

    public override void _PhysicsProcess(double delta)
    {
        InitionState.PhysicsUpdate(delta);

    }

    public override void _UnhandledInput(InputEvent @event)
    {
        InitionState.HandlessInput(@event);
    }

	public void ChangeState(string stateName, Variant stateNeed = new Variant())
    {
		if (!this.HasNode(stateName))
        {
			return;
        }

		InitionState.ExitState();
		InitionState = GetNode<State>(stateName);
		InitionState.EnterState(stateNeed);
		EmitSignal("TransitedEventHandler", stateName);
    }

}
