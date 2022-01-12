using Godot;
using System;

public class PlayerDetectionZone : Area2D
{
	public KinematicBody2D player;
	
	public static bool inside;
	
	public override void _Ready()
	{
		inside = false;
	}


	public bool can_see_player()
	{
		return inside;
	}
	/*
	private void _on_PlayerDetectionZone_body_entered(KinematicBody2D body)
	{
		GD.Print("work");
		player = body;
	}
	
	private void _on_PlayerDetectionZone_body_exited(object body)
	{
		player = null;
	}
	*/
	
	private void _on_PlayerDetectionZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			inside = true;
		}
	}

}


















