using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    Animator animator;
    ParticleSystem particle;

    int ballCount;

    [SerializeField] int checkCount;
    public int CheckCount { get { return checkCount; } set { checkCount = value; } }

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        particle = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        ballCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            ballCount++;
            animator.SetFloat(AnimString.Count, (float)ballCount/checkCount);
            if(ballCount >= checkCount && BallController.Instance.BallCount >= checkCount)
            {
                animator.SetBool(AnimString.IsClear, true);
            }
        }
    }

    public void StartParicle()
    {
        particle.Play();
    }
}
