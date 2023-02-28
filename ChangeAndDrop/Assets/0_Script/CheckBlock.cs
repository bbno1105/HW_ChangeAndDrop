using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    Animator animator;
    ParticleSystem particle;

    [SerializeField] int checkCount; // TODO : 데이터로 빼기
    int ballCount;

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
            UnityEngine.Debug.Log(ballCount);
            ballCount++;
            animator.SetFloat(AnimString.Check, (float)ballCount/checkCount);
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
