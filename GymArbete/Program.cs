global using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;



Raylib.InitWindow(1000, 800, "MemorieTest");

Raylib.SetTargetFPS(60);

List<Knapp> knappar = new();

int Poäng = 4;


for (var i = 0; i < 5; i++)
{
    Knapp k = new Knapp();
    k.number = i + 1;
    knappar.Add(k);
}

while (!Raylib.WindowShouldClose())
{

    if (Knapp.meny == true)
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText($"Välj Läge", 400, 300, 50, Color.BLACK);

        Rectangle UtanTimerKnapp = new Rectangle(400, 400, 200, 50);
        Raylib.DrawRectangleRec(UtanTimerKnapp, Color.GREEN);
        Raylib.DrawText($"Utan Timer", 450, 400, 20, Color.BLACK);


        Rectangle UpTimerKnapp = new Rectangle(400, 500, 200, 50);
        Raylib.DrawRectangleRec(UpTimerKnapp, Color.BLUE);
        Raylib.DrawText($"UpTimer", 450, 500, 20, Color.BLACK);


        Rectangle NedTimerKnapp = new Rectangle(400, 600, 200, 50);
        Raylib.DrawRectangleRec(NedTimerKnapp, Color.RED);
        Raylib.DrawText($"NedTimer", 450, 600, 20, Color.BLACK);



        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, UtanTimerKnapp))
            {
                Knapp.runda = true;
                Knapp.meny = false;
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, UpTimerKnapp))
            {
                Knapp.UpRunda = true;
                Knapp.meny = false;
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, NedTimerKnapp))
            {
                Knapp.NedRunda = true;
                Knapp.meny = false;
            }
        }
        Raylib.EndDrawing();
    }


    if (Knapp.NedRunda == true)
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
    if (Knapp.UpRunda == true)
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

    


    if (Knapp.NästaRunda == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Rectangle NästaRunda = new Rectangle(300, 350, 200, 100);

        Raylib.DrawText($"Din Nivå:{Poäng}", 300, 300, 50, Color.BLACK);
        Raylib.DrawText($"Nästa Runda", 300, 350, 100, Color.BLACK);
        Vector2 mousePos = Raylib.GetMousePosition();


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


    if (Knapp.runda == false && Knapp.gameover == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText($"Du förlora. Du fick {Poäng} poäng", 300, 300, 50, Color.BLACK);
        Raylib.EndDrawing();
    }
}