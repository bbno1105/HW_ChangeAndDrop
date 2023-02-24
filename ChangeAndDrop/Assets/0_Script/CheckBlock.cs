using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    [SerializeField] float BallCount; // TODO : µ¥ÀÌÅÍ·Î »©±â
    float checkBallCount;
    
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
        checkBallCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            checkBallCount++;
            animator.SetFloat("Check", checkBallCount/BallCount); // TODO : Hash
            if(checkBallCount >= BallCount && BallController.Instance.BallCount >= BallCount)
            {
                // ÆÄ±«
                animator.SetBool("IsClear", true); // TODO : Hash
            }
        }
    }

    public void StartParicle()
    {
        particle.Play();
    }
}
