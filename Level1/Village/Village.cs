using Godot;
using System;

public class Village : Node2D
{
 
	public override void _Ready()
	{
		
	}

	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Forest/Forest.tscn");	
		}
	}
	
	private void _on_Area2D2_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Forge/Forge.tscn");	
		}
	}
}






