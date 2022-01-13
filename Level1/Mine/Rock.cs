using Godot;
using System;

public class Rock : StaticBody2D
{
	public bool canTake = false;
	
	Label information;
	
	Color red = new Color(255, 0, 0, 255);
	
	public override void _Ready()
	{
		information = GetNode<Label>("Label");
			if(MC.language == "fr")
			{
				information.Text = "Appuyez sur R";
			}
			else
			{
				information.Text = "Press R";
			}
	}

	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			information.Visible = true;
			if(MC.ressources < 20)
			{
				
				canTake = true;
			}
			else
			{
				information.Modulate = red;
				information.Text = "Le sac est plein";
			}
			
		}
	}
	
	private void _on_Area2D_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			
			information.Visible = false;
			canTake = false;
		}
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.R)
			{
				if(canTake)
				{
					if(MC.ressources < 20)
					{
						MC.ressources ++;
					}
					QueueFree();
				}
			}
	}
}






