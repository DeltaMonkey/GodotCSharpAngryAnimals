using Godot;
using System;

public partial class Level : Node2D
{
	[Export] private Marker2D _animalStart;
	[Export] private PackedScene _animalScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalManager.Instance.OnAnimalDied += OnAnimalDied;
	}

    private void OnAnimalDied()
    {
		Animal newAnimal = (Animal)_animalScene.Instantiate();
		newAnimal.Position = _animalStart.Position;
		AddChild(newAnimal);
    }

    public override void _ExitTree()
    {
        SignalManager.Instance.OnAnimalDied -= OnAnimalDied;
    }

}
