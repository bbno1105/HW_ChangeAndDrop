using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        transform.position = new Vector3(2, 0, -8);
        target = transform;
    }

    void Update()
    {
        switch (PlayerController.Instance.PlayerState)
        {
            case PLAYERSTATE.INGAME:
                if(target.gameObject.activeSelf)
                {
                    transform.position = new Vector3(transform.position.x, target.position.y + 2, transform.position.z);
                }
                break;

            default:
                transform.position = new Vector3(transform.position.x, GameManager.Instance.NowBox.GetComponent<Box>().transform.position.y + 2, transform.position.z);
                break;
        }
        if(PlayerController.Instance.PlayerState != PLAYERSTATE.INGAME)
        {

        }
    }

    public void StartCameraMove()
    {
        StartCoroutine(SetTargetBall());
    }

    IEnumerator SetTargetBall()
    {
        while (PlayerController.Instance.PlayerState == PLAYERSTATE.INGAME)
        {
            // °ø Ã£±â
            for (int i = 0; i < BallController.Instance.BallPool.Count; i++)
            {
                if (BallController.Instance.BallPool[i].gameObject.activeSelf == false) continue;
                float ballPosition = BallController.Instance.BallPool[i].transform.position.y;
                if (ballPosition < target.position.y)
                {
                    target = BallController.Instance.BallPool[i].transform;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
