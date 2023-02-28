using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] COLORSTATE trapColor;
    public COLORSTATE TrapColor { get { return trapColor; } set { trapColor = value; } }

    [SerializeField] int bonusValue;
    public int BonusValue { get { return bonusValue; } set { bonusValue = value; } }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball") && trapColor != BallController.Instance.BallColor)
        {
            other.GetComponent<Ball>().DeActivate(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Ball") && transform.position.y < other.GetComponent<Ball>().CreatePositionY)
        {
            BallController.Instance.CreateBall(BonusValue, other.transform);
        }
    }
}
