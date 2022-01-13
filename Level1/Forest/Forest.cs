using Godot;
using System;

public class Forest : Node2D
{
	
	public override void _Ready()
	{
		
	}

	private void _on_ToMine_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Mine/Mine.tscn");
		}
	}
	
	private void _on_ToVillage_area_entered(Area2D area)
	{
	  	if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Village/Village2.tscn");
		}
	}
	private void _on_ToShipping_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Delivery/Delivery.tscn");
		}
	}
}


