using Godot;
using System;

public class IntroScene : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	bool released = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(MC.language == "en")
		{
			GetNode<Label>("Sprite/Label").Text = "Dear delivery man,\n\nThe Almighty requires your services of weapon delivery to help our armed\n pilgrimage go well. We ask of you to gather resources to make swords which \nyou will then deliver to the Supreme Siege.\n\nJoin our ranks by pressing Space and you shall be blessed with divine \nprotection!";

		
		}
		else
		{
			GetNode<Label>("Sprite/Label").Text = "Cher livreur,\n\nLe Tout Puissant fait appel à tes services pour délivrer des armes afin de\nmener à bien notre pèlerinage armé. Nous te demandons donc de récolter\ndes ressources  pour en faire des épées que tu livreras au Siège Suprème.\n\nRejoins nos rangs en appuyant sur Espace et tu seras béni d’une protection \ndivine !";

		
		}
	}

	public override void _Process(float delta)
	{
		if(Input.IsActionPressed("ui_attack"))
			{
				if(released == true)
				{
					GetTree().ChangeScene("res://Level1/Village/Village.tscn");
				}
			}
			else
			{
				released = true;
			}
	}
}
