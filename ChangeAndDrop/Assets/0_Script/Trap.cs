using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] COLORSTATE trapColor; // TODO : ������ ����
    public COLORSTATE TrapColor
    {
        get { return trapColor; }
        set 
        {
            trapColor = value;
            this.GetComponent<MeshRenderer>().material = TrapController.Instance.TrapMaterials[(int)trapColor];
        } 
    }

    [SerializeField] int bonusValue; // TODO : ������ ����

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        this.GetComponent<MeshRenderer>().material = TrapController.Instance.TrapMaterials[(int)trapColor];  
        // TODO : TrapColor�� �����Ϳ��� �޾ƿ���
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball") && trapColor != BallController.Instance.BallColor)
        {
            other.GetComponent<Ball>().DeActivate();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            BallController.Instance.CreateBall(bonusValue, other.GetComponent<Ball>());
        }
    }
}
