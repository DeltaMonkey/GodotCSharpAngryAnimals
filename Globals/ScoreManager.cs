using Godot;
using System;

public partial class ScoreManager : Node
{
	public const int DEFAULT_SCORE = 1000;

	public static ScoreManager Instance { get; private set; }

	private int _levelSelected { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static int GetLevelSelected()
	{
		return Instance._levelSelected;
	}

	public static int SetLevelSelected(int level)
	{
		return Instance._levelSelected = level;
	}

	public static int GetLevelBestScore()
	{
		return DEFAULT_SCORE;
	}
}
