using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATE
{
    NONE = 0,
    IDLE,
    READY,
    INGAME,
    CHECK
}

public enum COLORSTATE
{
    BLUE = 0,
    ORANGE
}

public static class GameData
{
    public static readonly Color OrangeColor = new Color(255f / 255f, 130f / 255f, 75f / 255f);
    public static readonly Color BlueColor = new Color(75f / 255f, 90f / 255f, 255f / 255f);
    public static readonly Color OrangeColorTransparent = new Color(255f / 255f, 130f / 255f, 75f / 255f, 0.4f);
    public static readonly Color BlueColorTransparent = new Color(75f / 255f, 90f / 255f, 255f / 255f, 0.4f);
}
