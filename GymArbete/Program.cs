global using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;



Raylib.InitWindow(1000, 800, "MemorieTest");

Raylib.SetTargetFPS(60);

List<Knapp> knappar = new();

int Poäng = 4;
bool meny = true;


for (var i = 0; i < 5; i++)
{
    Knapp k = new Knapp();
    k.number = i + 1;
    knappar.Add(k);
}

while (!Raylib.WindowShouldClose())
{

    if (meny == true)
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText($"Välj Läge", 300, 300, 50, Color.BLACK);

        Rectangle UtanTimerKnapp = new Rectangle(300, 350, 200, 100);
        Rectangle MedUpTimerKnapp = new Rectangle(300, 350, 200, 100);
        Rectangle MedNedTimerKnapp = new Rectangle(300, 350, 200, 100);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, UtanTimerKnapp))
            {

            }
            Raylib.EndDrawing();
        }
    }


    if (Knapp.runda == true)
    {


        Vector2 mousePos = Raylib.GetMousePosition();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        foreach (Knapp k in knappar)
        {
            k.Draw();
        }


        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {


            foreach (Knapp k in knappar)
            {

                if (Raylib.CheckCollisionPointRec(mousePos, k.rect))
                {
                    k.isClicked = true;
                    k.Check();
                    k.Shuffle();
                }
            }
        }


        int oklickade = knappar.Count(k => !k.isClicked);


        if (oklickade == 0)
        {
            Poäng++;
            Knapp.runda = false;

        }


        Raylib.EndDrawing();
    }


    if (Knapp.runda == false && Knapp.gameover == false)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Rectangle NästaRunda = new Rectangle(300, 350, 200, 100);
        // Vector2 mousePos = Raylib.GetMousePosition();

        Raylib.DrawText($"Din Poäng:{Poäng}", 300, 300, 50, Color.BLACK);
        Raylib.DrawText($"Nästa Runda", 300, 350, 100, Color.BLACK);


        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, NästaRunda))
            {

                foreach (Knapp k in knappar)
                {
                    k.isClicked = false;
                }

                Knapp kn = new Knapp();
                kn.number = knappar.Count + 1;
                knappar.Add(kn);

                Knapp.runda = true;

                Knapp.tracker = 0;
            }
        }
        Raylib.EndDrawing();
    }
    // Sen alla timers


    if (Knapp.runda == false && Knapp.gameover == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText($"Du förlora. Du fick {Poäng} poäng", 300, 300, 50, Color.BLACK);
        Raylib.EndDrawing();
    }
}