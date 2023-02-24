using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : SingletonBehaviour<BallController>
{
    [SerializeField] Material ballMaterial;
    public Material BallMaterial { get { return ballMaterial; } }
    [SerializeField] Material trailMaterial;
    public Material TrailMaterial { get { return trailMaterial; } }

    COLORSTATE ballColor;
    public COLORSTATE BallColor
    {
        get { return ballColor; }
        private set
        {
            ballColor = value;
            switch (ballColor)
            {
                case COLORSTATE.BLUE:
                    ballMaterial.color = GameData.BlueColor;
                    trailMaterial.color = GameData.BlueColorTransparent;
                    break;
                case COLORSTATE.ORANGE:
                    ballMaterial.color = GameData.OrangeColor;
                    trailMaterial.color = GameData.OrangeColorTransparent;
                    break;
            }
        }
    }

    [SerializeField] List<Ball> ballPool;
    Queue<Ball> ballPooling = new Queue<Ball>();

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        BallColor = COLORSTATE.BLUE;
        BallPooling();
    }

    public void ChangeColor()
    {
        if (BallColor == COLORSTATE.BLUE)
        {
            BallColor++;
        }
        else if (BallColor == COLORSTATE.ORANGE)
        {
            BallColor--;
        }
    }

    public void BallPooling()
    {
        for (int i = 0; i < ballPool.Count; i++)
        {
            if(ballPool[i].gameObject.activeSelf == false)
            {
                ballPooling.Enqueue(ballPool[i]);
            }
        }
    }

    public void CreateBall(int _ballCount, Vector3 _position)
    {
        for (int i = 0; i < ballPool.Count; i++)
        {
            if(ballPooling.Count == 0) BallPooling();
            if(ballPooling.Count > 0) ballPooling.Dequeue().Active(_position);
            if (--_ballCount < 0) return;
        }
    }
}