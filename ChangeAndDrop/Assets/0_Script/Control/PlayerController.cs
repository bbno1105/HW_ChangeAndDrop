using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBehaviour<PlayerController>
{
    PLAYERSTATE playerState;
    public PLAYERSTATE PlayerState { get { return playerState; } set { playerState = value; } }

    [SerializeField] float mouseSpeed;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        PlayerState = PLAYERSTATE.IDLE;
    }

    void Update()
    {
        InputKey();
    }

    void InputKey()
    {
        switch (PlayerState)
        {
            case PLAYERSTATE.IDLE:
                if (Input.GetMouseButtonDown(0))
                {
                    playerState = PLAYERSTATE.READY;
                }
                break;
            case PLAYERSTATE.READY:
                if (Input.GetMouseButtonDown(0)) // if (Input.GetMouseButtonUp(0)) 모바일 터치조작은 테스트 필요
                {
                    playerState = PLAYERSTATE.INGAME;
                    GameManager.Instance.NowBox.StartBox();
                }
                else
                {
                    MoveBox();
                }
                break;
            case PLAYERSTATE.INGAME:
                if (Input.GetMouseButtonDown(0))
                {
                    BallController.Instance.ChangeColor();
                }
                break;
            case PLAYERSTATE.End:
                break;
            default:
                break;
        }
    }

    void MoveBox()
    {
        float mouseMove = Input.GetAxis("Mouse X");
        Vector3 boxPosition = GameManager.Instance.NowBox.transform.position;
        
        if (mouseMove > 0)
        {
            float newPositionX = boxPosition.x + mouseSpeed * mouseMove * Time.deltaTime;
            if (newPositionX > 0.75f) newPositionX = 0.75f;
            GameManager.Instance.NowBox.transform.position = new Vector3(newPositionX, boxPosition.y, boxPosition.z);
        }
        else if (mouseMove < 0)
        {
            float newPositionX = boxPosition.x + mouseSpeed * mouseMove * Time.deltaTime;
            if (newPositionX < -0.75f) newPositionX = -0.75f;
            GameManager.Instance.NowBox.transform.position = new Vector3(newPositionX, boxPosition.y, boxPosition.z);
        }
    }
}
