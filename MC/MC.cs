using Godot;
using System;

public class MC : KinematicBody2D
{

	[Export]
	public Vector2 Velocity;
	public static string voices = "en";
	const int MAXSPEED = 200;
	const int ACCELERATION = 525;
	private int FRICTION = 1000;
	Sprite currentSprite;
	AnimationPlayer animationPlayer;
	AnimationTree animationTree;
	AnimationNodeStateMachinePlayback animationState;

  	bool inverted = false;
	
	public static int life = 10;
	
	bool released = false;
	
	bool[] timer = new bool[300];

	public static Vector2 pos;
	
	public static int ressources = 0;
	
	public static int rocks = 0;
	
	Label score;
	
	Label ScoreWood;
	
	Label livraison;
	
	public static string language = "en";

	public static float DirectionX;
	public static float DirectionY;

	private enum State{
		MOVE,
		ATTACK,
		HURT,
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
		score = GetNode<Label>("Camera2D/CanvasLayer/score");
		ScoreWood = GetNode<Label>("Camera2D/CanvasLayer/scoreWood");
		livraison = GetNode<Label>("Camera2D/CanvasLayer/bool");
	}


	public Vector2 GetInput()
	{
		var input_vector = Vector2.Zero;
		
		input_vector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		input_vector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		input_vector = input_vector.Normalized();
		if(inverted == true)
		{
			return -input_vector;
		}
		return input_vector;
	}

  	public override void _PhysicsProcess(float delta)
  	{	
		if(Forge.delievery_ready)
		{
			livraison.Text = "oui";
		}
		ScoreWood.Text = rocks.ToString();				
		score.Text = ressources.ToString();
		tick();
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
			case State.HURT:
				animationState.Travel("Hurt");
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
	
	private void dead_state(float delta)
	{
		Velocity = Vector2.Zero;
		QueueFree();
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
	
	private void start_timer()
	{
		for(int i = 0; i < 300; i++)
		{
			timer[i] = true;
		}
	}
	
	private void tick()
	{
		for(int i = 0; i < 300; i++)
		{
			if(timer[i] == true)
			{
				GD.Print(i);
				timer[i] = false;
				inverted = true;
				return;
			}
		}
		inverted = false;
	}
	
	private void _on_Mushroom1_poison()
	{
		start_timer();
	}
	private void _on_Hurtbox_area_entered(Area2D area)
	{
		if(area.IsInGroup("sword"))
		{
			if(life > 0)
			{
				life --;
				state = State.HURT;
			}
			else
			{
				QueueFree();
			}
		}
	}
}





