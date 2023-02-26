using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    [SerializeField] int checkCount; // TODO : µ¥ÀÌÅÍ·Î »©±â
    int ballCount;
    
    Animator animator;
    ParticleSystem particle;

    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        particle = this.gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        ballCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            ballCount++;
            animator.SetFloat(AnimString.Check, (float)ballCount/checkCount);
            if(ballCount >= checkCount && BallController.Instance.BallCount >= checkCount)
            {
                // ÆÄ±«
                animator.SetBool(AnimString.IsClear, true);
            }
        }
    }

    public void StartParicle()
    {
        particle.Play();
    }
}
