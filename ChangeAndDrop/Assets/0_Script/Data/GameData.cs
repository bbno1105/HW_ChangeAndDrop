using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    static Color orangeColor = new Color(255f/255f, 130f/255f, 75f/255f);
    public static Color OrangeColor { get { return orangeColor; } }
    static Color blueColor = new Color(75f/255f, 90f/255f, 255f/255f);
    public static Color BlueColor { get { return blueColor; } }
    static Color orangeColorTransparent = new Color(255f/255f, 130f/255f, 75f/255f, 0.4f);
    public static Color OrangeColorTransparent { get { return orangeColorTransparent; } }
    static Color blueColorTransparent = new Color(75f/255f, 90f/255f, 255f/255f, 0.4f);
    public static Color BlueColorTransparent { get { return blueColorTransparent; } }
}
