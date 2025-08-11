using Godot;
using System;

public partial class SignalManager : Node
{
	public static SignalManager Instance { get; private set; }

	[Signal] public delegate void OnAnimalDiedEventHandler();
	[Signal] public delegate void OnCupDestroyedEventHandler();
	[Signal] public delegate void OnLevelCompletedEventHandler();
	[Signal] public delegate void OnAttemptMadeEventHandler();
	[Signal] public delegate void OnAttemptUpdatedEventHandler(int num);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void EmitOnAnimalDied()
	{
		Instance.EmitSignal(SignalName.OnAnimalDied);
	}

	public static void EmitOnCupDestroyed()
	{
		Instance.EmitSignal(SignalName.OnCupDestroyed);
	}

	public static void EmitOnLevelCompleted()
	{
		Instance.EmitSignal(SignalName.OnLevelCompleted);
	}

	public static void EmitOnAttemptMade()
	{
		Instance.EmitSignal(SignalName.OnAttemptMade);
	}

	public static void EmitOnAttemptUpdated(int num)
	{
		Instance.EmitSignal(SignalName.OnAttemptUpdated, num);
	}
}
