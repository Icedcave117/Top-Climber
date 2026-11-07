using Raylib_cs;
public class Player
{
    public int PlayerRadius = 20;
    public int PosY = Raylib.GetScreenHeight() - 20;
    public int PosX = Raylib.GetScreenWidth() / 2;
    public int PosSpeedX = 10;
    public int PosSpeedY = 10;
    public bool IsItOnGround = true;
}