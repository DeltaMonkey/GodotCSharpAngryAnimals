using Godot;
using System;

public partial class Scorer : Node
{
	private int _totalCups = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_totalCups = GetTree().GetNodeCountInGroup(Cup.GROUP_NAME);
		GD.Print($"Scorer found {_totalCups} Cups");
	}
}
