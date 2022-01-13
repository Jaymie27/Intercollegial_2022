using Godot;
using System;

public class Forge : Node2D
{
	public bool isEntering;	
	
	Label T;
	
	Label F;
	
	Label L;
	
	public override void _Ready()
	{
		isEntering = true;
		T = GetNode<Label>("Label");
		F = GetNode<Label>("Label2");
		L = GetNode<Label>("Label3");
	}
	
	private void _on_Area2D_area_entered(Area2D area)
	{				
		if(area.IsInGroup("player"))
		{
			GetTree().ChangeScene("res://test.tscn");
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
























