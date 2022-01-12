using Godot;
using System;

public class Forge : Node2D
{
	public bool isEntering;	
	
	public override void _Ready()
	{
		isEntering = true;
	}
	
	private void _on_Area2D_area_entered(Area2D area)
	{				
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://test.tscn");
		}
	}
	
}






