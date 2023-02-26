using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    enum BOXSTATE
    {
        START,
        CHECK,
        FINISH
    }
    [SerializeField] BOXSTATE boxState;
    float ballCount;
    
    [Header("CheckBox")]
    [SerializeField] int checkCount;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        switch (boxState)
        {
            case BOXSTATE.CHECK:
                animator.SetBool(AnimString.IsCheckBox, true);
                break;

            case BOXSTATE.FINISH:
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

            case BOXSTATE.FINISH:
                ballCount++;
                animator.SetFloat(AnimString.Check, (float)ballCount / checkCount);

                if (ballCount > checkCount)
                {
                    animator.SetBool(AnimString.IsFinish, true);
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    if(ballCount == BallController.Instance.BallCount)
                    {
                        StartCoroutine(FinishEffet());
                    }
                }
                else
                {
                    other.GetComponent<Ball>().DeActivate();
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
        BallController.Instance.CreateBall(BallController.Instance.BallCount, transform.position);
    }

    IEnumerator FinishEffet()
    {
        yield return new WaitForSecondsRealtime(3);
        PlayerController.Instance.SetEnd();
        // บüนใ~
    }
}
