using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator animator;
    
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
    public int CheckCount { get { return checkCount; } set { checkCount = value; } }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
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
                    other.tag = "CheckedBall";
                    PlayerController.Instance.PlayerState = PLAYERSTATE.CHECK;

                    other.GetComponent<Ball>().DeActivate();
                    animator.SetFloat("Count", (float)ballCount / checkCount);

                    if (ballCount > checkCount && ballCount == BallController.Instance.BallCount)
                    {
                        animator.SetBool(AnimString.IsClear, true);
                    }
                }
                break;

            case BOXSTATE.FINISH:
                if (other.tag.Equals("Ball"))
                {
                    ballCount++;
                    other.tag = "CheckedBall";
                    PlayerController.Instance.PlayerState = PLAYERSTATE.CHECK;

                    animator.SetFloat(AnimString.Count, (float)ballCount / checkCount);
                    if (ballCount > checkCount)
                    {
                        animator.SetBool(AnimString.IsFinish, true);
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                        if(ballCount == BallController.Instance.BallCount)
                        {
                            StopCoroutine(FinishEffet());
                            StartCoroutine(FinishEffet());
                        }
                    }
                    else
                    {
                        other.GetComponent<Ball>().DeActivate();
                    }
                }
                break;

            default:
                break;
        }
    }

    public void StartBox()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(AnimString.IsStart);
    }

    public void StartBall() // Animation Event
    {
        PlayerController.Instance.PlayerState = PLAYERSTATE.INGAME;
        Camera.main.GetComponent<CameraController>().StartCameraMove();
        BallController.Instance.CreateBall(BallController.Instance.BallCount, transform.position);
    }

    public void SetStartBox() // Animation Event
    {
        boxState = BOXSTATE.START;
        PlayerController.Instance.PlayerState = PLAYERSTATE.IDLE;
    }

    public void NextBox() // Animation Event
    {
        GameManager.Instance.NextBox();
    }

    IEnumerator FinishEffet()
    {
        yield return new WaitForSecondsRealtime(4);
        BallController.Instance.PopBall();
    }
}
