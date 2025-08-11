using Godot;
using System;

public partial class Scorer : Node
{
	private int _totalCups = 0;
	private int _cupsHit = 0;
	private int _attempts = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalManager.Instance.OnCupDestroyed += OnCupDestroyed;
		SignalManager.Instance.OnAttemptMade += OnAttemptMade;

		_totalCups = GetTree().GetNodeCountInGroup(Cup.GROUP_NAME);
		GD.Print($"Scorer found {_totalCups} Cups");
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnCupDestroyed -= OnCupDestroyed;
		SignalManager.Instance.OnAttemptMade -= OnAttemptMade;
	}

	private void OnCupDestroyed()
	{
		_cupsHit++;
		if (_cupsHit == _totalCups)
		{
			SignalManager.EmitOnLevelCompleted();
			GD.Print("Level Completed");
		}
	}

	private void OnAttemptMade()
	{
		_attempts++;
		SignalManager.EmitOnAttemptUpdated(_attempts);
		GD.Print("Attempts:", _attempts);
	}
}
