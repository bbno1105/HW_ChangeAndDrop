using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    [SerializeField] int checkCount;
    float ballCount;

    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            ballCount++;
            other.GetComponent<Ball>().DeActivate();
            animator.SetFloat("Check", (float)ballCount/checkCount);

            if (ballCount > checkCount && ballCount == BallController.Instance.BallCount) ;
            {
                animator.SetBool("IsClear", true);
            }
        }
    }
}
