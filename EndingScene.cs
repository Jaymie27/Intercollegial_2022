using Godot;
using System;

public class EndingScene : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MC.life = 10;
		MC.ressources = 0;
		MC.rocks = 0;
		if(MC.language == "fr")
		{
			GetNode<Label>("Sprite/Label").Text = "Félicitations!";
			GetNode<Label>("Sprite/Label2").Text = "Appuyez sur Espace pour retourner au menu";
		}
		else
		{
			GetNode<Label>("Sprite/Label").Text = "Congratulations!";
			GetNode<Label>("Sprite/Label2").Text = "Press space to return to title screen";
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
