using Godot;
using System;

public class Rock : StaticBody2D
{
	public bool canTake = false;
	
	Label information;
	
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
			canTake = true;
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
					QueueFree();
				}
			}
	}
}






