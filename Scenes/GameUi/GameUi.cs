using Godot;
using System;

public partial class GameUi : Control
{
	[Export] private Label _levelLabel;
	[Export] private Label _attemptsLabel;
	[Export] private VBoxContainer _vbGameOver;
	[Export] private AudioStreamPlayer _gameOverMusic;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_levelLabel.Text = $"Level {ScoreManager.GetLevelSelected()}";

		SignalManager.Instance.OnLevelCompleted += OnLevelCompleted;
		SignalManager.Instance.OnAttemptUpdated += OnAttemptUpdated;
	}

    public override void _ExitTree()
    {
        SignalManager.Instance.OnLevelCompleted -= OnLevelCompleted;
		SignalManager.Instance.OnAttemptUpdated -= OnAttemptUpdated;
    }

    private void OnAttemptUpdated(int num)
	{
		_attemptsLabel.Text = $"Attempts: {num}";
	}

    private void OnLevelCompleted()
	{
		_vbGameOver.Show();
		_gameOverMusic.Play();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_vbGameOver.Visible && Input.IsKeyPressed(Key.Space))
		{
			GameManager.LoadMain();
		}
	}
}
