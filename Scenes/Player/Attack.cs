using Godot;
using System;

public partial class Attack : State
{


	private CharacterBody2D _player;
	private Timer _dashTimer;


	private float _moveSpeed = 10000.0f;
	private  Vector2 _direction;
	




	public override void EnterState(Variant _need = default)
	{
		base.EnterState(_need);

		_player = Owner as CharacterBody2D;
		_dashTimer = GetNode<Timer>("DashTimer");
		_dashTimer.Start();
		_dashTimer.Timeout += () => StateMachine.ChangeState("Walk", _direction);


		_direction = (Vector2)_need;
	}

	public override void PhysicsUpdate(double _delta)
	{
		base.Update(_delta);
		MoveToTarget();

	}

	private void MoveToTarget()
    {
		Vector2 bodyVelocity = _player.Velocity;

		bodyVelocity = _player.GlobalPosition.DirectionTo(_direction) * _moveSpeed * (float)GetPhysicsProcessDeltaTime();
		_player.Velocity = bodyVelocity;
		_player.MoveAndSlide();
    }





}
