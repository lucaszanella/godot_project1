using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    // Member variables here, example:
    private int a = 2;
    private string b = "textvar";
    private Vector2 velocity;
    private Vector2 screensize;

    private Vector2 GRAVITY = new  Vector2(0,20);

    const int VELOCITY = 10;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
           
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
        this.Position += GRAVITY;
          // Called every frame. Delta is time since last frame.
        // Update game logic here.
        velocity = new Vector2();
        if(Input.IsActionPressed("ui_right") || Input.IsKeyPressed((int)KeyList.D)) {
            velocity.x += VELOCITY;
        }
        
        if(Input.IsActionPressed("ui_left") || Input.IsKeyPressed((int)KeyList.A)) {
            velocity.x -= VELOCITY;
        }
        /* 
        if(Input.IsActionPressed("ui_down") || Input.IsKeyPressed((int)KeyList.S)) {
            velocity.y += VELOCITY;
        }
        */

        if(Input.IsActionPressed("ui_up") || Input.IsKeyPressed((int)KeyList.W)) {
            //velocity.y -= VELOCITY;
        }   
        this.Position += velocity;

    
        this.SetPosition(this.Position); 
  }
}
