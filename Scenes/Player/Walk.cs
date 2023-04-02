using Godot;
using System;

public partial class Walk : State
{
    [Export]
    private Sprite2D _sprite;
    

    [Export]
    private float _acceleration = 700.0f;
    [Export]
    private float _maxSpeed = 2500.0f;

    private int _direction = 1;

    private CharacterBody2D _body;



    public override void EnterState(Variant _need = default)
    {
        _body = Owner as CharacterBody2D;
    }


    public override void PhysicsUpdate(double _delta)
    {
        Movement();
    }


    private void Movement()
    {
        double deltaTime = GetPhysicsProcessDeltaTime();
        Vector2 bodyVelocity = _body.Velocity;


        if (_body.IsOnWall()) { FlipDirection(); }

        bodyVelocity.X += _acceleration * _direction * (float)deltaTime;
        bodyVelocity = bodyVelocity.LimitLength(_maxSpeed * (float)deltaTime);
        _body.Velocity = bodyVelocity;
        _body.MoveAndSlide();

    }



    private void FlipDirection()
    {
        if (_sprite != null) { _sprite.FlipH = !_sprite.FlipH; }
        _direction *= -1; 
       
    }

}
