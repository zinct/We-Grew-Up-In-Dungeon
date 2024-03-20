using Godot;
using System;

public partial class PlayerAttackState : State
{
    public const float Speed = 300.0f;
	private PlayerAnimationManager _animationManager;
    private CharacterBody2D _characterBody2D;    
    private float _previousDirection;

    public override void Ready()
    {
        _characterBody2D = (CharacterBody2D)GetTree().GetFirstNodeInGroup("PlayerCharacterBody2D");
        _animationManager = (PlayerAnimationManager)GetTree().GetFirstNodeInGroup("PlayerAnimationTree");
    }

	public override void Enter()
	{
		_animationManager.SetAttack(true);
	}

	public override void PhysicsUpdate(double delta)
	{
		Vector2 velocity = _characterBody2D.Velocity;

		float horizontalDirection = Input.GetAxis("move_player_left", "move_player_right");
		float verticalDirection = Input.GetAxis("move_player_up", "move_player_down");

		if(horizontalDirection != 0)
			_previousDirection = horizontalDirection;

		if (horizontalDirection != 0)
			velocity.X = horizontalDirection * Speed;
		else
			velocity.X = Mathf.MoveToward(velocity.X, 0, 50);

		if (verticalDirection != 0)
			velocity.Y = verticalDirection * Speed;
		else
			velocity.Y = Mathf.MoveToward(velocity.Y, 0, 50);

		if (horizontalDirection != 0 || verticalDirection != 0)
			velocity = velocity.Normalized() * Speed;

		_characterBody2D.Velocity = velocity;
		_characterBody2D.MoveAndSlide();
	}


	public override void Exit()
	{
		_animationManager.SetAttack(false);
	}
	
	private void OnAnimationTreeAnimationFinished(StringName anim_name)
	{
		if(anim_name == "attack_right" || anim_name == "attack_left")
        	fsm.TransitionTo(fsm.previousState.Name.ToString().ToLower());
	}

}









