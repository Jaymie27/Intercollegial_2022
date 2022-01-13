using Godot;
using System;

public class OptionsMenu : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	enum selection {LANGUAGE, VOICES, RETURN};
	selection currentSelection = selection.LANGUAGE;
	
	enum selection2 {FRENCH, ENGLISH};
	
	selection2 currentSelection2 = selection2.ENGLISH;
	selection2 currentSelection3 = selection2.ENGLISH;
	
	bool released = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D2").Position;
		GetNode<Sprite>("Sprite/Selection2").Position = GetNode<Position2D>("Sprite/Position2D6").Position;
		GetNode<Sprite>("Sprite/Selection3").Position = GetNode<Position2D>("Sprite/Position2D4").Position;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		 if(Input.IsActionPressed("ui_down"))
			{
				if(released == true)
				{
					released = false;
					if(currentSelection == selection.LANGUAGE)
					{
						currentSelection = selection.VOICES;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D").Position;
					}
					else if(currentSelection == selection.VOICES)
					{
						currentSelection = selection.RETURN;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D3").Position;
					}
				}
			}
			else if(Input.IsActionPressed("ui_up"))
			{
				if(released == true)
				{
					released = false;
					if(currentSelection == selection.RETURN)
					{
						currentSelection = selection.VOICES;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D").Position;
					}
					else if(currentSelection == selection.VOICES)
					{
						currentSelection = selection.LANGUAGE;
						GetNode<Sprite>("Sprite/Selection").Position = GetNode<Position2D>("Sprite/Position2D2").Position;
					}
				}
			}
			else if((Input.IsActionPressed("ui_right")) || (Input.IsActionPressed("ui_left")))
			{
				if(released == true)
				{
					if(currentSelection == selection.LANGUAGE)
					{
						released = false;
						if(currentSelection2 == selection2.ENGLISH)
						{
							MC.language = "fr";
							currentSelection2 = selection2.FRENCH;	
							GetNode<Sprite>("Sprite/Selection2").Position = GetNode<Position2D>("Sprite/Position2D7").Position;
						}
						else
						{
							MC.language = "en";
							currentSelection2 = selection2.ENGLISH;	
							GetNode<Sprite>("Sprite/Selection2").Position = GetNode<Position2D>("Sprite/Position2D6").Position;
						}
					}
					else if(currentSelection == selection.VOICES)
					{
						released = false;
						if(currentSelection3 == selection2.ENGLISH)
						{
							currentSelection3 = selection2.FRENCH;	
							GetNode<Sprite>("Sprite/Selection3").Position = GetNode<Position2D>("Sprite/Position2D5").Position;
						}
						else
						{
							currentSelection3 = selection2.ENGLISH;	
							GetNode<Sprite>("Sprite/Selection3").Position = GetNode<Position2D>("Sprite/Position2D4").Position;
						}
					}
				}
			}
			else
			{
				released = true;
			}
	}
}
