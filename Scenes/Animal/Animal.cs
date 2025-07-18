using Godot;
using System;

public partial class Animal : RigidBody2D
{
	[Export] private Label _label;
	[Export] private AudioStreamPlayer2D _stretchSound;
	[Export] private AudioStreamPlayer2D _launchSound;
	[Export] private AudioStreamPlayer2D _kickSound;
	[Export] private Sprite2D _arrow;
	[Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_visibleOnScreenNotifier.ScreenExited += OnScreenExited;
	}

    private void OnScreenExited()
    {
		GD.Print("OnScreenExited");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
