using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

InitWindow(400, 630, "Top Climber");
SetTargetFPS(30);

Player player = new Player();
Platformer platformer = new Platformer();
FinishLine finishLine = new FinishLine();
Random random = new Random();

platformer.BoxPosX = random.Next(50,150);
platformer.BoxPosY = random.Next(125,250);

platformer.FirstPosX = random.Next(300,390);
platformer.FirstPosY = random.Next(150,290);

platformer.ThirdPosX = random.Next(270,340);
platformer.ThirdPosY = random.Next(370, 420);

platformer.FourthPosX = random.Next(50,120);
platformer.FourthPosY = random.Next(450,530);

while(!WindowShouldClose())
{
    Vector2 playerCircle = new Vector2(player.PosX, player.PosY);
    Rectangle platformRectangle = new Rectangle(platformer.BoxPosX, platformer.BoxPosY, 
    platformer.BoxWidth, platformer.BoxHeight);
    Rectangle platformRectangle2 = new Rectangle(platformer.FirstPosX, platformer.FirstPosY, 
    platformer.BoxWidth, platformer.BoxHeight);
    Rectangle platformRectangle4 = new Rectangle(platformer.ThirdPosX, platformer.ThirdPosY, 
    platformer.BoxWidth, platformer.BoxHeight);
    Rectangle platformRectangle5 = new Rectangle(platformer.FourthPosX, platformer.FourthPosY, 
    platformer.BoxWidth, platformer.BoxHeight);
    Rectangle FinishBlock = new Rectangle(finishLine.FinishLineX, finishLine.FinishLineY,
    finishLine.Width, finishLine.Height);

    if(IsKeyDown(KeyboardKey.A))
    {
        player.PosX -= player.PosSpeedX;
    }

    if(IsKeyDown(KeyboardKey.D))
    {
        player.PosX += player.PosSpeedX;
    }

    if(player.PosX >= GetScreenWidth() - player.PlayerRadius)
    {
        player.PosX = GetScreenWidth() - player.PlayerRadius;
    }

    if(player.PosX < 0)
    {
        player.PosX = player.PlayerRadius;
    }

    if(IsMouseButtonDown(MouseButton.Left))
    {
        player.IsItOnGround = false;
        player.PosY -= player.PosSpeedY;
    }
    if (IsMouseButtonUp(MouseButton.Left))
    {
        if(player.IsItOnGround == false)
        {
            player.PosY += player.PosSpeedY;
        }

        if(player.PosY >= GetScreenHeight() - player.PlayerRadius)
        {
            player.IsItOnGround = true;
            if(player.IsItOnGround == true)
            {
                player.PosY = GetScreenHeight() - player.PlayerRadius;
            }
        }
    }

    if(CheckCollisionCircleRec(playerCircle, player.PlayerRadius, platformRectangle))
    {
        player.PosY = platformer.BoxPosY - player.PlayerRadius;
    }

    if(CheckCollisionCircleRec(playerCircle, player.PlayerRadius, platformRectangle2))
    {
        player.PosY = platformer.FirstPosY - player.PlayerRadius;
    }

    if(CheckCollisionCircleRec(playerCircle, player.PlayerRadius, platformRectangle4))
    {
        player.PosY = platformer.ThirdPosY - player.PlayerRadius;
    }

    if(CheckCollisionCircleRec(playerCircle, player.PlayerRadius, platformRectangle5))
    {
        player.PosY = platformer.FourthPosY - player.PlayerRadius;
    }

    if(CheckCollisionCircleRec(playerCircle, player.PlayerRadius, FinishBlock))
    {
        player.PosY = GetScreenHeight() - player.PlayerRadius;
        finishLine.PlayerScore += 10;

        platformer.BoxPosX = random.Next(50,150);
        platformer.BoxPosY = random.Next(125,250);

        platformer.FirstPosX = random.Next(300,390);
        platformer.FirstPosY = random.Next(150,290);

        platformer.ThirdPosX = random.Next(270,340);
        platformer.ThirdPosY = random.Next(370, 420);

        platformer.FourthPosX = random.Next(50,120);
        platformer.FourthPosY = random.Next(450,530);
    }

    BeginDrawing();
    ClearBackground(Color.Black);
    DrawCircle(player.PosX, player.PosY, player.PlayerRadius, Color.Blue);
    DrawRectangle(platformer.BoxPosX, platformer.BoxPosY, platformer.BoxWidth, platformer.BoxHeight, Color.Red);
    DrawRectangle(platformer.FirstPosX, platformer.FirstPosY, platformer.BoxWidth, platformer.BoxHeight, Color.Green);
    DrawRectangle(platformer.ThirdPosX, platformer.ThirdPosY, platformer.BoxWidth, platformer.BoxHeight, Color.Blue);
    DrawRectangle(platformer.FourthPosX, platformer.FourthPosY, platformer.BoxWidth, platformer.BoxHeight, Color.Orange);
    DrawText("Score: " + finishLine.PlayerScore, 50, 30, 25, Color.White);
    DrawRectangle(finishLine.FinishLineX, finishLine.FinishLineY, finishLine.Width, finishLine.Height, Color.SkyBlue);
    EndDrawing();
}

CloseWindow();
