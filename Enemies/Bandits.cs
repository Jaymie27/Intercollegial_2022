using Godot;
using System;
using System.Collections.Generic;

public class Bandits : KinematicBody2D
{
	private enum state{
		IDLE,
		WANDER,
		CHASE
	};
	
	private int ACCELERATION = 300;
	private int MAX_SPEED = 50;
	private int FRICTION = 200;

	private int wander_target_range = 4;

	private state currentState;
	
	public Vector2 Velocity;
	public Vector2 Direction;
	Area2D playerDetectionZone;
	KinematicBody2D player;
	AnimatedSprite aSprite;
	
	
}
