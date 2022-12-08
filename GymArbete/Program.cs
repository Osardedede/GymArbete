global using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;



Raylib.InitWindow(1000, 800, "MemorieTest");

Raylib.SetTargetFPS(60);

List<Knapp> knappar = new();

int Poäng = 4;
float UpStart = 0;
float NedStart = 16;
bool VäljaUpp = false;
bool VäljaNed = false;
bool VäljaNormal = false;




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
                VäljaNormal = true;
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, UpTimerKnapp))
            {
                Knapp.UpRunda = true;
                Knapp.meny = false;
                VäljaUpp = true;
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, NedTimerKnapp))
            {
                Knapp.NedRunda = true;
                Knapp.meny = false;
                VäljaNed = true;
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


        if (Knapp.Räknatimer == true)
        {

            NedStart -= Raylib.GetFrameTime();
            int hej = (int)NedStart;
            Raylib.DrawText($"{hej}", 0, 0, 50, Color.BLACK);

            if (hej < 0)
            {
                Knapp.NedRunda = false;
                Knapp.gameover = true;
            }
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
                    Knapp.Räknatimer = false;


                }
            }
        }


        int oklickade = knappar.Count(k => !k.isClicked);

        if (oklickade == 0)
        {
            Poäng++;
            Knapp.NedRunda = false;
            Knapp.NästaRunda = true;
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

        // börja timer

        // float timerCurrentValue = 0;
        // timerCurrentValue++;





        if (Knapp.Räknatimer == true)
        {

            UpStart += Raylib.GetFrameTime();
            int hej = (int)UpStart;
            Raylib.DrawText($"{hej}", 0, 0, 50, Color.BLACK);

            if (hej < 0)
            {
                Knapp.NedRunda = false;
                Knapp.gameover = true;
                Knapp.Räknatimer = false;
            }
        }
        // timerCurrentValue += Raylib.GetFrameTime();
        // int hej = (int)timerCurrentValue;







        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {


            foreach (Knapp k in knappar)
            {

                if (Raylib.CheckCollisionPointRec(mousePos, k.rect))
                {
                    k.isClicked = true;
                    k.Check();
                    k.Shuffle();
                    Knapp.Räknatimer = false;

                    // Sluta timer
                }
            }
        }


        int oklickade = knappar.Count(k => !k.isClicked);


        if (oklickade == 0)
        {
            Poäng++;
            Knapp.UpRunda = false;
            Knapp.NästaRunda = true;

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
            Knapp.NästaRunda = true;

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

                if (VäljaUpp == true)
                {
                    Knapp.UpRunda = true;
                    Knapp.NästaRunda = false;
                    UpStart = 0;
                    Knapp.Räknatimer = true;


                }
                if (VäljaNed == true)
                {
                    Knapp.NedRunda = true;
                    Knapp.NästaRunda = false;
                    NedStart = 16;
                    Knapp.Räknatimer = true;

                }

                if (VäljaNormal == true)
                {
                    Knapp.runda = true;
                    Knapp.NästaRunda = false;
                }

                Knapp.tracker = 0;
            }
        }
        Raylib.EndDrawing();
    }


    if (Knapp.gameover == true)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        if (Poäng > 4)
        {
            Raylib.DrawText($"Du förlora. Du fick {Poäng} poäng", 300, 300, 50, Color.BLACK);
        }
        else
        {
            Raylib.DrawText($"Du förlora. Du fick 0 poäng", 300, 300, 50, Color.BLACK);

        }
        Raylib.EndDrawing();
    }
}