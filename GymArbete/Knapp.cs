using System;

class Knapp
{
    public Rectangle rect;
    public int number;
    public bool isClicked = false;
    public static int tracker = 0;
    public static bool gameover = false;
    public static bool runda = false;
    public static bool UpRunda = false;
    public static bool NedRunda = false;
    public static bool meny = true;
    public static bool NästaRunda = false;
    public static bool Räknatimer = true;





    public Knapp()
    {
        rect = new Rectangle(0, 0, 64, 64);
        Shuffle();
    }

    public void Draw()
    {
        if (!isClicked)
        {
            Raylib.DrawRectangleRec(rect, Color.BLUE);

            if (tracker == 0)
            {
                Raylib.DrawText(number.ToString(), (int)rect.x + 10, (int)rect.y + 10, 30, Color.WHITE);
            }
        }
    }

    public void Shuffle()
    {
        Random kordinat = new Random();
        rect.x = kordinat.Next(Raylib.GetScreenWidth() - (int)rect.width);
        rect.y = kordinat.Next(Raylib.GetScreenHeight() - (int)rect.height);


    }

    public void Check()
    {
        tracker++;

        if (number > tracker)
        {
            runda = false;
            UpRunda = false;
            NedRunda = false;
            gameover = true;
            Räknatimer = false;
        }
    }
}