using Godot;
using System;

public class WanderController : Node2D
{
	
	[Export]
	private int wander_range= 500;
	private Vector2 start_position;
	private Vector2 target_position;

	private Timer timer;

	public Vector2 get_target_position()
	{
		return target_position;
	}
	public override void _Ready()
	{
		start_position = GlobalPosition;
		update_target_position();
		timer = GetNode<Timer>("Timer");
	}


	public void update_target_position()
	{
		var rand = new Random();
		var target_vector = new Vector2(rand.Next(-wander_range, wander_range), rand.Next(-wander_range, wander_range));
		target_position = start_position + target_vector;
	}

	public float getTimeLeft()
	{
		return timer.TimeLeft;
	}

	public void start_wander_timer(float duration)
	{
		timer.Start(duration);
	}

	private void _on_Timer_timeout()
	{
		update_target_position();
	}
}



