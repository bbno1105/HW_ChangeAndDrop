using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] COLORSTATE trapColor; // TODO : 데이터 빼기
    public COLORSTATE TrapColor { get { return trapColor; } set { trapColor = value; } }

    [SerializeField] int bonusValue; // TODO : 데이터 빼기
    public int BonusValue { get { return bonusValue; } set { bonusValue = value; } }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        this.GetComponent<MeshRenderer>().material = TrapController.Instance.TrapMaterials[(int)trapColor];
        // TODO : TrapColor를 데이터에서 받아오기
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball") && trapColor != BallController.Instance.BallColor)
        {
            other.GetComponent<Ball>().DeActivate();
            BallController.Instance.BallCount--;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            BallController.Instance.CreateBall(BonusValue, other.GetComponent<Ball>());
        }
    }
}
