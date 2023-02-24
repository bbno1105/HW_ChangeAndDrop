using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    Animator animator;
    [SerializeField] float BallCount; // TODO : µ¥ÀÌÅÍ·Î »©±â
    float checkBallCount;

    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        checkBallCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            checkBallCount++;
            animator.SetFloat("Check", checkBallCount/BallCount);
            if(checkBallCount >= BallCount && BallController.Instance.BallCount >= BallCount)
            {
                UnityEngine.Debug.Log("ÆÄ±«");
                // ÆÄ±«
            }
        }
    }
}
