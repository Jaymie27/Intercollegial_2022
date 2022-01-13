using Godot;
using System;

public class TitleScreen : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	enum selection {PLAY, OPTIONS, EXIT};
	selection currentSelection = selection.PLAY;
	
	bool released = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D2").Position;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		  if(Input.IsActionPressed("ui_down"))
			{
				if(released == true)
				{
					released = false;
					if(currentSelection == selection.PLAY)
					{
						currentSelection = selection.OPTIONS;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D").Position;
					}
					else if(currentSelection == selection.OPTIONS)
					{
						currentSelection = selection.EXIT;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D3").Position;
					}
				}
			}
			else if(Input.IsActionPressed("ui_up"))
			{
				if(released == true)
				{
					released = false;
					if(currentSelection == selection.EXIT)
					{
						currentSelection = selection.OPTIONS;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D").Position;
					}
					else if(currentSelection == selection.OPTIONS)
					{
						currentSelection = selection.PLAY;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D2").Position;
					}
				}
			}
			else if(Input.IsActionPressed("ui_attack"))
			{
				if(released == true)
				{
					released = false;
					if(currentSelection == selection.PLAY)
					{
						GetTree().ChangeScene("res://IntroScene/IntroScene.tscn");
						QueueFree();
					}
					else if(currentSelection == selection.OPTIONS)
					{
						GetTree().ChangeScene("res://OptionsMenu/OptionsMenu.tscn");
						QueueFree();
					}
					else if(currentSelection == selection.EXIT)
					{
						GetTree().Quit();
					}
				}
			}
			else
			{
				released = true;
			}
	}
}
