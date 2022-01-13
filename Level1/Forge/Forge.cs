using Godot;
using System;

public class Forge : Node2D
{		
	
	Label T;
	
	Label F;
	
	Label L;
	
	Label label;
	
	Label label2;
	
	Label label3;
	
	Color green = new Color(0,254,4,255);
	
	public override void _Ready()
	{
		T = GetNode<Label>("t");
		F = GetNode<Label>("f");
		L = GetNode<Label>("l");
	}
	
	
	private void _on_Area2D_area_entered(Area2D area)
	{				
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://Level1/Mine/Mine.tscn");
		}
	}
	
	private void _on_Tzone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			T.Visible = true;
		}
	}
	
	private void _on_Tzone_area_exited(Area2D area)
	{
		if(area.IsInGroup("player"))
		{ 
			
				T.Visible = false;
		
		}
	}
	
	private void _on_FZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			F.Visible = true;
		}
	}
	
	private void _on_FZone_area_exited(Area2D area)
	{
	   	if(area.IsInGroup("player"))
		{
			F.Visible = false;
		}
	}
	
	private void _on_LZone_area_entered(Area2D area)
	{
		if(area.IsInGroup("player"))
		{
			L.Visible = true;
		}
	}
	
	private void _on_LZone_area_exited(Area2D area)
	{
	   	if(area.IsInGroup("player"))
		{
			L.Visible = false;
		}
	}
}
























