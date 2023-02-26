using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : SingletonBehaviour<BallController>
{
    // Material
    [SerializeField] Material ballMaterial;
    public Material BallMaterial { get { return ballMaterial; } }
    [SerializeField] Material trailMaterial;
    public Material TrailMaterial { get { return trailMaterial; } }

    // Object Pooling
    [SerializeField] List<Ball> ballPool;
    Queue<Ball> ballPooling = new Queue<Ball>();

    // Ball State
    int ballCount;
    public int BallCount { get { return ballCount; } set { ballCount = value; } }

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

    public void CreateBall(int _ballCount, Transform _ball)
    {
        Vector3 position = _ball.position;
        Vector3 velocity = _ball.GetComponent<Rigidbody>().velocity;
        for (int i = 1; i < _ballCount; i++)
        {
            BallCount++;
            float setValue = (i / 2) * Mathf.Pow(-1f, i);
            Vector3 newPosition = new Vector3(position.x + setValue/15f, position.y, position.z);

            if (ballPooling.Count == 0) BallPooling();
            if (ballPooling.Count > 0)
            {
                ballPooling.Dequeue().Activate(newPosition, velocity, setValue);
            }
        }
    }
}
