using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class State : Node
{
	public StateMachine StateMachine;



    public virtual void Update(double _delta)
    {

    }

    public virtual void PhysicsUpdate(double _delta)
    {

    }

    public virtual void HandlessInput(InputEvent _event)
    {

    }

    public virtual void EnterState(Variant _need = new Variant()) 
    {
       
    }
        
    public virtual void ExitState()
    {

    }

}
