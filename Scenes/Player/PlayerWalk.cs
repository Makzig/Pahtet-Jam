using Godot;
using System;

public partial class PlayerWalk : Walk
{

    public override void EnterState(Variant _need = default)
    {
        base.EnterState(_need);

    }

    public override void HandlessInput(InputEvent _event)
    {
        base.HandlessInput(_event);
        if (_event is InputEventMouseButton eventMouseButton && _event.IsPressed())
        {
            StateMachine.ChangeState("Attack", eventMouseButton.GlobalPosition);
        }
    }

}


