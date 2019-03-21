using Godot;
using System;

public class Node2D : Godot.Node2D
{
    // Member variables here, example:
    private int a = 2;
    private string b = "textvar";
    private Vector2 velocity;
    private Vector2 screensize;

private CollisionShape2D collision_shape;
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here.
        GD.Print("Hello from C# to Godot :)");
        collision_shape = GetNode("CollisionShape2D") as CollisionShape2D;
        screensize = GetViewport().GetSize();
        OS.SetWindowSize(new Vector2(1920, 1080));
    }

    public override void _Process(float delta)
    {
  
        
    }
}
