using Godot;
using System;

public class PlayerDetectionZone : Area2D
{
	public KinematicBody2D player;
	
	public override void _Ready()
	{
		player = null;
	}


	public bool can_see_player()
	{
		return player != null;
	}
	
	private void _on_PlayerDetectionZone_body_entered(KinematicBody2D body)
	{
		GD.Print("work");
		player = body;
	}
	
	private void _on_PlayerDetectionZone_body_exited(object body)
	{
		player = null;
	}
	

}















