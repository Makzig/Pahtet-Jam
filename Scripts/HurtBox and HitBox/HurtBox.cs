using Godot;
using System;

public partial class HurtBox : Area2D
{
    [Signal]
    public delegate void HurtEventHandler();

    public override void _Ready()
    {
        this.AreaEntered +=  _OnHurt;
    }


    private void _OnHurt(Area2D area)
    {
        if (area.IsInGroup("HitBox")){
            EmitSignal("HurtEventHandler");
        }
    }

}
