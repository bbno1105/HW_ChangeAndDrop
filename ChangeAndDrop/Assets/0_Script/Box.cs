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
        animator = this.GetComponent<Animator>();
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
                animator.SetBool(AnimString.IsCheckBox, true);
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
                    animator.SetFloat(AnimString.Check, (float)ballCount / checkCount);

                    if (ballCount > checkCount && ballCount == BallController.Instance.BallCount)
                    {
                        animator.SetBool(AnimString.IsClear, true);
                    }
                }
                break;
            default:
                break;
        }
    }

    public void StartBox()
    {
        animator.SetBool(AnimString.IsStart, true);
    }

    public void StartBall()
    {
        BallController.Instance.CreateBall(BallController.Instance.BallCount, this.transform);
    }
}
