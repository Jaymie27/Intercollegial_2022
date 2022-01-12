using Godot;
using System;

public class MC : KinematicBody2D
{

	[Export]
	public Vector2 Velocity;

	const int MAXSPEED = 200;
	const int ACCELERATION = 525;
	private int FRICTION = 1000;
	Sprite currentSprite;
	AnimationPlayer animationPlayer;
	AnimationTree animationTree;
	AnimationNodeStateMachinePlayback animationState;

  	bool inverted = false;
	
	bool released = true;

	public static Vector2 pos;

	public static float DirectionX;
	public static float DirectionY;

	private enum State{
		MOVE,
		ATTACK,
		DEAD,
		PICKUP
	};

	State state;

	public override void _Ready()
	{
		currentSprite = GetNode<Sprite>("Sprite");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationState = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
		pos = this.GlobalPosition;
	}


	public Vector2 GetInput()
	{
		var input_vector = Vector2.Zero;
		
		input_vector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		input_vector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		input_vector = input_vector.Normalized();
		return input_vector;
	}

  	public override void _PhysicsProcess(float delta)
  	{	
		pos = this.GlobalPosition;	  
		switch(state){
			case State.MOVE:
				move_state(delta);
				break;
			case State.ATTACK:
				attack_state(delta);
				break;
			case State.PICKUP:
				pickup_state(delta);
				break;
		}	 
  	}
	
	
	private void move_state(float delta)
	{		
		 var input_vector = GetInput();
		
		
		
			if(Input.IsActionPressed("ui_attack"))
			{
				if(released == true)
				{
					if(inverted == true)
					{
						state = State.PICKUP;
					}
					else
					{
						state = State.ATTACK;
					}
					released = false;
				}
			}
			else if(Input.IsActionPressed("pup"))
			{
				if(released == true)
				{
					if(inverted == true)
					{
						state = State.ATTACK;
					}
					else
					{
						state = State.PICKUP;
					}
					released = false;
				}
			}
			else
			{
				released = true;
			}
		if(input_vector != Vector2.Zero)
		{
			animationTree.Set("parameters/Idle/blend_position", input_vector);
			animationTree.Set("parameters/Run/blend_position", input_vector);
			animationTree.Set("parameters/Attack/blend_position", input_vector);
			animationState.Travel("Run");
			
			
			Velocity = Velocity.MoveToward(input_vector * MAXSPEED, ACCELERATION * delta);    
		}
		else
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, FRICTION * delta);
			animationState.Travel("Idle");
		}
		
		DirectionX = Velocity.x;
		DirectionY = Velocity.y;
		Velocity = MoveAndSlide(Velocity);
	}
	
	private void attack_state(float delta)
	{
		Velocity = Vector2.Zero;
		animationState.Travel("Attack");
	}
	
	private void pickup_state(float delta)
	{
		Velocity = Vector2.Zero;
		animationState.Travel("Pick Up");
	}
	
	public void attack_animation_finished()
	{
		state = State.MOVE;
	}
	
}



