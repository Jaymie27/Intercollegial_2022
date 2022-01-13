using Godot;
using System;
using System.Collections.Generic;

public class Bandits : KinematicBody2D
{
	private enum state{
		IDLE,
		WANDER,
		CHASE,
		ATTACK,
		HURT,
		DEAD
	};
	
	private int ACCELERATION = 300;
	private int MAX_SPEED = 80;
	private int FRICTION = 200;

	private int wander_target_range = 4;

	private int life = 3;
	
	private state currentState;
	
	public Vector2 Velocity;
	public Vector2 Direction;
	KinematicBody2D player;
	Sprite aSprite;
	AnimationPlayer animationPlayer;
	AnimationTree animationTree;
	AnimationNodeStateMachinePlayback animationState;
	WanderController wanderController;
	
	List<state> states = new List<state>{state.IDLE, state.WANDER};
	
	public override void _Ready()
	{
		Velocity = Vector2.Zero;
		currentState = pick_random_state(states);
		aSprite = GetNode<Sprite>("Sprite");
		wanderController = GetNode<WanderController>("WanderController");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationState = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
	}
	
	public override void _PhysicsProcess(float delta)
  {
	animationTree.Set("parameters/Idle/blend_position", Velocity);
	animationTree.Set("parameters/Run/blend_position", Velocity);
	animationTree.Set("parameters/Attack/blend_position", Velocity);
	switch (currentState)
	{
	  case state.IDLE:
		Velocity = Velocity.MoveToward(Vector2.Zero, FRICTION * delta);
		animationState.Travel("Idle");
		seek_player();
		if(wanderController.getTimeLeft() == 0)
		{
			GD.Print("idle");
			update_wander();
		}

		break;

	  case state.WANDER:
		GD.Print("wander");
		animationState.Travel("Run");
		seek_player();
		if(wanderController.getTimeLeft() == 0)
		{
			
			update_wander();
		}
	
		accelerate_towards_point(wanderController.get_target_position(), delta);
		
		string p = wanderController.get_target_position().ToString();
		string mypos = this.Position.ToString();
		//GD.Print("target :");
		//GD.Print(p);
		//GD.Print(mypos);
		

		if(this.GlobalPosition.DistanceTo(wanderController.get_target_position()) <= wander_target_range)
		{
			update_wander();
		}

		break;
		
	  case state.CHASE:
		GD.Print("Chase");
		animationState.Travel("Run");
		//player = (GetNode("PlayerDetectionZone") as PlayerDetectionZone).player;
		
		accelerate_towards_point(MC.pos, delta);
			//Direction = (MC.pos - this.GlobalPosition).Normalized();	
			//Velocity = Velocity.MoveToward(Direction * MAX_SPEED, ACCELERATION);		
		
		break;
		
		case state.ATTACK:
			GD.Print("Attack");
			animationState.Travel("Attack");
			Velocity = Vector2.Zero;
			//accelerate_towards_point(MC.pos, delta);
		break;
		
		case state.HURT:
			 animationState.Travel("Hurt");
		break;
		
		case state.DEAD:
			animationState.Travel("Death");
		break;
	}
	
	Velocity = MoveAndSlide(Velocity);
		
  }


	private void update_wander()
	{
		currentState = pick_random_state(states);
		Random rand = new Random();
		wanderController.start_wander_timer(rand.Next(1, 3));
	}
	private void accelerate_towards_point(Vector2 point, float delta)
	{
		Direction = this.GlobalPosition.DirectionTo(point);
		Velocity = Velocity.MoveToward(Direction * MAX_SPEED, ACCELERATION * delta);
		//aSprite.FlipH = Velocity.x < 0;
	}
	private void seek_player()
	{
		if(PlayerDetectionZone.inside == true)
		{
			GD.Print("goInside");
			currentState = state.CHASE;
		}
	}

	private state pick_random_state(List<state> state_list)
	{
		//GD.Print("passe");
		Random rand = new Random();
		state_list = Shuffle<state> (state_list, rand);
		return state_list[0];
		
	}
	
	private void MEURT()
	{
		if(life <= 0)
		{
			QueueFree();
		}
		else
		{
			currentState = pick_random_state(states);
		}
	}

	private List<T> Shuffle<T>(List<T> list, Random rnd)
	{
		for(var i=list.Count; i > 0; i--)
		{
			Swap(list, 0, rnd.Next(0, i));
		}
		return list;
	}

	private void Swap<T>( List<T> list, int i, int j)
	{
		var temp = list[i];
		list[i] = list[j];
		list[j] = temp;
	}
	private void _on_test_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			currentState = state.CHASE;
		}
	}
	private void _on_test_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			currentState = pick_random_state(states);
		}
	}
	private void _on_attackzone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			currentState = state.ATTACK;
		}
	}
	private void _on_attackzone_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			currentState = state.CHASE;
		}
	}
	
	private void attack_finished()
	{
		EmitSignal("attack");
		GD.Print("hey criss");
	}
	
	private void _on_Hurtbox_area_entered(Area2D area)
	{
		if(area.IsInGroup("sword"))
		{
		  life --;
		  if(life <= 0)
		  {
			 currentState = state.DEAD;
		  }
		  else
		  {
			 currentState = state.HURT;
		  }
		}
	}
	
	
	
	[Signal]
	public delegate void attack();
}















