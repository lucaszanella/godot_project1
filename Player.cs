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

    private Sprite target;

    private double targetRotation = -Math.PI/2;

    [Export]
    float targetRadius = 400;
    const int VELOCITY = 10;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        target = ((GetNode("chicken") as Sprite).GetNode("target") as Sprite);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
        // do jeito que estava quanto mais frames sua máquina for capaz de processar
        // mais rapido o Player irá se mexer, e isso não é ideal
        // é necessário multiplicar toda unidade de movimento pelo 'delta' fornecido pela engine
        // assim vc transforma o GRAVITY e VELOCITY que devem estar na unidade distancia/segundo
        // para a unidade distancia/frame
        // OBS.: se esses valores foram testados por feeling para descobrir qual fica mais legal em jogo
        //  será necessário realizar os teste de novo, desta vez mantendo em mente que a unidade é distancia/segundo
        
        this.Position += GRAVITY * delta;
          // Called every frame. Delta is time since last frame.
        // Update game logic here.
        velocity = new Vector2();
        if(Input.IsActionPressed("ui_right") || Input.IsKeyPressed((int)KeyList.D)) {
            velocity.x += VELOCITY;
            (GetNode( "chicken" ) as Sprite).SetFlipH(true);
        }
        
        if(Input.IsActionPressed("ui_left") || Input.IsKeyPressed((int)KeyList.A)) {
            velocity.x -= VELOCITY;
            (GetNode( "chicken" ) as Sprite).SetFlipH(false);
        }
        
        // para rotação também é importante multiplicar por delta
        // para transformar a unidade de rotação de graus(?)/segundo para graus/frame
        if(Input.IsActionPressed("ui_down") || Input.IsKeyPressed((int)KeyList.S)) {
            targetRotation -= 0.05 * delta;
        }
        

        if(Input.IsActionPressed("ui_up") || Input.IsKeyPressed((int)KeyList.W)) {
            targetRotation += 0.05 * delta;
        }
        
        this.Position += velocity * delta; // ao usar o MoveAndCollide isso aqui se tornaria redundante?

        target.SetRotation((float) targetRotation);
        target.SetPosition(new Vector2(targetRadius*(float) Math.Cos(targetRotation), targetRadius*(float) Math.Sin(targetRotation)));

    
        //this.SetPosition(this.Position); 
        MoveAndCollide(velocity * delta);
  }
}
