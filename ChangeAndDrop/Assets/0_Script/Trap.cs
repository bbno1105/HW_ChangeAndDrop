using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] COLORSTATE trapColor; // TODO : 데이터 빼기
    public COLORSTATE TrapColor
    {
        get { return trapColor; }
        set 
        {
            trapColor = value;
            this.GetComponent<MeshRenderer>().material = TrapController.Instance.TrapMaterials[(int)trapColor];
        } 
    }

    [SerializeField] int bonusValue; // TODO : 데이터 빼기

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
        if(trapColor != BallController.Instance.BallColor)
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
        BallController.Instance.CreateBall(bonusValue, other.transform.position);
    }
}
