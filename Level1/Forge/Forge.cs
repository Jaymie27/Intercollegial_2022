using Godot;
using System;

public class Forge : Node2D
{		
	
	Label T;
	
	Label F;
	
	Label L;
	
	bool canT = false;
	
	bool canF = false;
	
	bool canL = false;
	
	bool isFrontT = false;
	
	bool isFrontF = false;
	
	bool isFrontL = false;
	
	public static bool delievery_ready = false;
	
	Color green = new Color(0,254,4,255);
	
	public override void _Ready()
	{
		T = GetNode<Label>("t");
		F = GetNode<Label>("f");
		L = GetNode<Label>("l");
		
		if(MC.language == "fr")
		{
			T.Text = "Non disponible";
			F.Text = "Non disponible";
			L.Text = "Non disponible";
			GetNode<Label>("Label").Text = "Tremper les ressources";
			GetNode<Label>("Label2").Text = "Forger";
			GetNode<Label>("Label3").Text = "Prendre la livraison";
		}
		else
		{
			T.Text = "Unavailable";
			F.Text = "Unavailable";
			L.Text = "Unavailable";
			GetNode<Label>("Label").Text = "Temper resources";
			GetNode<Label>("Label2").Text = "Forge";
			GetNode<Label>("Label3").Text = "Take the delivery";
		}
	}
	
	public override void _Process(float delta)
  	{	
		if(MC.ressources == 20 && MC.rocks == 5)
		{
			T.Visible = true;
			T.Modulate = green;
			if(MC.language == "fr")
			{
				T.Text = "Appuyez sur E";
			}
			else
			{
				T.Text = "Press E";
			}
			canT = true;
		}
	}	
	
	private void _on_Area2D_area_entered(Area2D area)
	{				
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Village/Village.tscn");
		}
	}
	
	private void _on_Tzone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			T.Visible = true;
			isFrontT = true;
		}
	}
	
	private void _on_Tzone_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{ 
			
			if(T.Modulate != green)
			{
				T.Visible = false;
			}	
			isFrontT = false;
		}
	}
	
	private void _on_FZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			F.Visible = true;
			isFrontF = true;
		}
	}
	
	private void _on_FZone_area_exited(Area2D area)
	{
	   	if(area.IsInGroup("player"))
		{
			if(F.Modulate != green)
			{
				F.Visible = false;
			}			
			isFrontF = false;
		}
	}
	
	private void _on_LZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			L.Visible = true;
			isFrontL = true;
		}
	}
	
	private void _on_LZone_area_exited(Area2D area)
	{
	   	if(area.IsInGroup("player"))
		{
			if(L.Modulate != green)
			{
				L.Visible = false;
			}	
			isFrontL = false;
		}
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.E)
			{
				if(canT && isFrontT)
				{
					MC.ressources = 0;
					MC.rocks = 0;
					if(MC.language == "fr")
					{
						T.Text = "Fait";
					}
					else
					{
						T.Text = "Done";
					}
					canT = false;
					canF = true;
					F.Visible = true;
					if(MC.language == "fr")
					{
						F.Text = "Appuyez sur E";
					}
					else
					{
						F.Text = "Press E";
					}
					F.Modulate = green;
				}
				
				if(canF && isFrontF)
				{
					if(MC.language == "fr")
					{
						F.Text = "Fait";
					}
					else
					{
						F.Text = "Done";
					}
					canF = false;
					canL = true;
					L.Visible = true;
					if(MC.language == "fr")
					{
						L.Text = "Appuyez sur E";
					}
					else
					{
						L.Text = "Press E";
					}
					L.Modulate = green;
				}
			
			
				if(canL && isFrontL)
				{
					if(MC.language == "fr")
					{
						L.Text = "Vous pouvez livrer!";
					}
					else
					{
						L.Text = "You can deliver!";
					}
					canL = false;
					delievery_ready = true;
				}	
			}
			
				
			
	}
}
























