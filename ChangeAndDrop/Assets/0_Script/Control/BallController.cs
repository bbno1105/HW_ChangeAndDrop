using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : SingletonBehaviour<BallController>
{
    [SerializeField] Material ballMaterial;
    public Material BallMaterial { get { return ballMaterial; } }

    COLORSTATE ballColor;
    public COLORSTATE BallColor { get { return ballColor; } private set { ballColor = value; } }

    public void ChangeColor()
    {
        if (ballColor == COLORSTATE.BLUE)
        {
            ballColor++; // ballColor = Color.ORANGE;
            ballMaterial.color = GameData.OrangeColor;
        }
        else if (ballColor == COLORSTATE.ORANGE)
        {
            ballColor--;
            ballMaterial.color = GameData.BlueColor;
        }
    }
}
