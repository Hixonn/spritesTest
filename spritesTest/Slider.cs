using System;
using System.Collections.Generic;
using Raylib_cs;
public class Slider
{
    Rectangle bar = new Rectangle();
    Rectangle nob = new Rectangle();
    int sliderRange;
    int nobIndent;
    bool ignoreY = false;
    int startAt;
    Color nobClr;
    Color barClr;
    float sliderX;
    public Slider(float barX, float barY, float barW, float barH, int valueRange, int indent, int start = 0, Color? nobColor = null, Color? barColor = null, bool reverse = false)
    {
        sliderX = barX;
        if (start > valueRange)
        {
            startAt = valueRange;
        }
        else if (start < 0)
        {
            startAt = 0;
        }
        else
        {
            startAt = start;
        }

        nobClr = nobColor ?? Color.WHITE;
        barClr = barColor ?? Color.BLACK;
        sliderRange = valueRange;
        nobIndent = indent;

        bar = new Rectangle(barX, barY, barW, barH);
        nob = new Rectangle(bar.x + nobIndent, bar.y + nobIndent, bar.height - nobIndent * 2, bar.height - nobIndent * 2);
        nob.x += Convertion * startAt;

    }

    public void Update()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) == true && Raylib.GetMouseX() > bar.x && Raylib.GetMouseX() < bar.width + bar.x && Raylib.GetMouseY() > bar.y && Raylib.GetMouseY() < bar.height + bar.y)
        {
            ignoreY = true;
        }
        if (ignoreY == true)
        {
            NobX = Raylib.GetMouseX();
        }
        if (Raylib.IsMouseButtonUp(MouseButton.MOUSE_LEFT_BUTTON) == true)
        {
            ignoreY = false;
        }
    }




    public Rectangle Bar
    {
        get { return bar; }
        set { bar = value; nob = new Rectangle(((bar.width - (nob.width + nobIndent * 2)) / sliderRange) * SliderValue + bar.x + nobIndent, bar.y + nobIndent, bar.height - nobIndent * 2, bar.height - nobIndent * 2); }
    }
    public Rectangle Nob { get; set; }
    public int GetSliderRange { get { return sliderRange; } }
    public float NobX
    {
        get
        {
            return nob.x;
        }

        set
        {
            if (value < bar.width + bar.x && value > bar.x)
            {

                // NOB IS BIG
                if (value > bar.width + bar.x - (nob.width / 2) - nobIndent)
                {
                    nob.x = bar.x + bar.width - nob.width - nobIndent;
                }
                // NOB IS SMALL
                else if (value < bar.x + nob.width / 2 + nobIndent)
                {
                    nob.x = bar.x + nobIndent;
                }
                else
                {
                    nob.x = value - nob.width / 2;
                }
            }
        }
    }


    public float Convertion
    {
        get
        {
            return (bar.width - (nob.width + nobIndent * 2)) / sliderRange;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(bar, barClr);
        Raylib.DrawRectangleRec(nob, nobClr);
        Raylib.DrawText($"{Convert.ToInt32((nob.x - nobIndent - bar.x) / (Convertion))}", Convert.ToInt32(bar.x + bar.width + nobIndent + 10), Convert.ToInt32(bar.y + 10), Convert.ToInt32(bar.height), Color.BLACK);
        Raylib.DrawText($"{Convert.ToInt32((nob.x - nobIndent - bar.x) / (Convertion))}", Convert.ToInt32(bar.x + bar.width + nobIndent + 10), Convert.ToInt32(bar.y + 5), Convert.ToInt32(bar.height), Color.BLACK);
        Raylib.DrawText($"{Convert.ToInt32((nob.x - nobIndent - bar.x) / (Convertion))}", Convert.ToInt32(bar.x + bar.width + nobIndent + 5), Convert.ToInt32(bar.y + 10), Convert.ToInt32(bar.height), Color.BLACK);
        Raylib.DrawText($"{Convert.ToInt32((nob.x - nobIndent - bar.x) / (Convertion))}", Convert.ToInt32(bar.x + bar.width + nobIndent + 5), Convert.ToInt32(bar.y + 5), Convert.ToInt32(bar.height), Color.WHITE);

    }

    public int SliderValue { get { return Convert.ToInt32((nob.x - nobIndent - bar.x) / (Convertion)); } }
}
