using Godot;
using System;

public class Bandits : KinematicBody2D
{
	private enum state{
		IDLE,
		CHASE
	};
	
	private int ACCELERATION = 300;
	private int MAX_SPEED = 50;
	private int FRICTION = 200;
	
	private state currentState;
	
	public Vector2 Velocity;
	public Vector2 Direction;
	Area2D playerDetectionZone;
	KinematicBody2D player;
	AnimatedSprite aSprite;
	
	public override void _Ready()
	{
		Velocity = Vector2.Zero;
		playerDetectionZone = GetNode<Area2D>("PlayerDetectionZone");
		aSprite = GetNode<AnimatedSprite>("AnimatedSprite");		
	}
	
	
}
