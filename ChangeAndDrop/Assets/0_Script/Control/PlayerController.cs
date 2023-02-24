using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBehaviour<PlayerController>
{
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {

    }

    void Update()
    {
        switch (GameManager.Instance.PlayerState)
        {
            case PLAYERSTATE.READY:
                break;
            case PLAYERSTATE.INGAME:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    BallController.Instance.ChangeColor();
                    UnityEngine.Debug.Log("BallColor : " + BallController.Instance.BallColor);
                }
                break;
            default:
                break;
        }
    }





}
