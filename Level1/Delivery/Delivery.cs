using Godot;
using System;

public class Delivery : Node2D
{
  
	Label label;
	
	bool finish = false;

	public override void _Ready()
	{
		label = GetNode<Label>("Label");
	}

	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Forest/Forest3.tscn");	
		}
	}
	
	private void _on_Area2D2_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			label.Visible = true;
			if(Forge.delievery_ready)
			{
				if(MC.language == "fr")
				{
					label.Text = "Bon travail! Appuyez sur F";
				}
				else
				{
					label.Text = "Good work! Press F";
				}
				finish = true;
			}
			else
			{
				if(MC.language == "fr")
				{
					label.Text = "Retourne travailler! Nous attendons votre livraison!";
				}
				else
				{
					label.Text = "Get back to work! We are waiting for your delivery!";
				}
			}
		}
	}
	private void _on_Area2D2_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			label.Visible = false;
			finish = false;
		}
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.F)
			{
				if(finish)
				{
					GetTree().ChangeScene("res://EndingScene.tscn");	
				}
			}
	}
}









