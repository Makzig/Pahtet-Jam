using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private float _accelaration = 200f;
	private float _maxSpeed = 3000f;
	private float _direction = 1f;


	private void _Movement()
    {
		float delta_time =  (float)GetPhysicsProcessDeltaTime();
		Vector2 velocity = Velocity;

		velocity.X += _accelaration * _direction * delta_time;
		velocity = Velocity.LimitLength(_maxSpeed * delta_time);
		if (IsOnWall())
        {
			_direction *= -1;
        }
		MoveAndSlide();
    }

    public override void _PhysicsProcess(double delta)
    {
		_Movement();
		GD.Print(_direction);

    }


}
