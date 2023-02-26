using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    enum BOXSTATE
    {
        START,
        CHECK
    }
    BOXSTATE boxState;
    [SerializeField] bool isStartBox;
    float ballCount;
    
    [Header("CheckBox")]
    [SerializeField] int checkCount;

    Animator animator;

    void Awake()
    {
        animator = this.GetComponentInParent<Animator>();
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        boxState = isStartBox ? BOXSTATE.START : BOXSTATE.CHECK;

        switch (boxState)
        {
            case BOXSTATE.START:
                break;
            case BOXSTATE.CHECK:
                animator.SetBool("IsCheckBox", true);
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (boxState)
        {
            case BOXSTATE.START:
                break;
            case BOXSTATE.CHECK:
                if (other.tag.Equals("Ball"))
                {
                    ballCount++;
                    other.GetComponent<Ball>().DeActivate();
                    animator.SetFloat("Check", (float)ballCount / checkCount);

                    if (ballCount > checkCount && ballCount == BallController.Instance.BallCount)
                    {
                        animator.SetBool("IsClear", true);
                    }
                }
                break;
            default:
                break;
        }
    }


}
