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

                default:
                    break;
            }
        }
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
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

        if(ballPooling.Count == 0)
        {
            for (int i = 0; i < 500; i++)
            {
                GameObject newBall = Instantiate(ballPool[0].gameObject, ballPool[0].transform.parent);
                newBall.SetActive(false);
                ballPool.Add(newBall.GetComponent<Ball>());
            }
            BallPooling();
        }
    }

    public void CreateBall(int _ballCount, Transform _ball)
    {
        Vector3 position = _ball.position;
        Vector3 velocity = _ball.GetComponent<Rigidbody>().velocity;
        --_ballCount;
        StartCoroutine(CreateBallCoroutine(_ballCount, position, velocity));
    }

    public void CreateBall(int _ballCount, Vector3 _position)
    {
        StartCoroutine(CreateBallCoroutine(_ballCount, _position, Vector3.zero, true));
    }

    IEnumerator CreateBallCoroutine(int _ballCount, Vector3 _position, Vector3 _velocity, bool _isStartBox = false)
    {
        for (int i = 0; i < _ballCount; i++)
        {
            yield return new WaitForEndOfFrame();
            float setValue = (Random.Range(0,1f)) * Mathf.Pow(-1f, i);
            Vector3 newPosition = new Vector3(_position.x + setValue / 15f, _position.y, _position.z);

            if (ballPooling.Count == 0) BallPooling();
            if (ballPooling.Count > 0)
            {
                Ball ball = ballPooling.Dequeue();
                ball.Activate(newPosition, _velocity, setValue);

                if (!_isStartBox) ++BallCount;
            }
        }
    }

    public void PopBall()
    {
        for (int i = 0; i < ballPool.Count; i++)
        {
            if(ballPool[i].gameObject.activeSelf)
            {
                ballPool[i].PopBall();
            }
        }
    }
}
