using Godot;
using System;

public class Oak : StaticBody2D
{
	Label label;

	Color red = new Color(255, 0, 0, 255);
	
	public override void _Ready()
	{
		label = GetNode<Label>("Label");
	}
	
	private void _on_Area2D_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			label.Visible = true;
			if(MC.rocks == 5)
			{
				if(MC.language == "fr")
				{
					label.Text = "Plein";
				}
				else
				{
					label.Text = "Full";
				}
				label.Modulate = red;
			}
			else
			{
				if(MC.language == "fr")
				{
					label.Text = "Appuyez sur Espace";
				}
				else
				{
					label.Text = "Press space";
				}
			}
		}	
		if(area.IsInGroup("sword"))
		{
			if(MC.rocks < 5)
			{
				MC.rocks ++;
				QueueFree();
			}			
		}
	}
	
	private void _on_Area2D_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			label.Visible = false;
		}
	}

}






