using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    MeshRenderer meshRenderer;
    TrailRenderer trailRenderer;
    Rigidbody rigidbody;

    float maxVelocityY = 1f;
    float minVelocityY = -3f; 
    float maxVelocityX = 3f;
    float minVelocityX = -3f;

    void Awake()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        trailRenderer = this.GetComponent<TrailRenderer>();
        rigidbody = this.GetComponent<Rigidbody>();

        meshRenderer.material = BallController.Instance.BallMaterial;
        trailRenderer.material = BallController.Instance.TrailMaterial;
    }

    void OnEnable()
    {
        this.gameObject.layer = 8;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 0)
        {
            this.gameObject.layer = 7;
        }
    }

    void Update()
    {
        LimitSpeed();
    }

    void LimitSpeed()
    {
        Vector3 nowSpeed = rigidbody.velocity;
        if (nowSpeed.x < minVelocityX)
        {
            rigidbody.velocity = new Vector3(-3, nowSpeed.y, nowSpeed.z);
        }
        if (nowSpeed.x > maxVelocityX)
        {
            rigidbody.velocity = new Vector3(3, nowSpeed.y, nowSpeed.z);
        }
        if (nowSpeed.y < minVelocityY)
        {
            rigidbody.velocity = new Vector3(nowSpeed.x, -3f, nowSpeed.z);
        }
        if (nowSpeed.y > maxVelocityY)
        {
            rigidbody.velocity = new Vector3(nowSpeed.x, 1f, nowSpeed.z);
        }
    }

    public void Activate(Vector3 _position, Vector3 _nowVelocity ,float _setVelocity)
    {
        this.transform.position = _position;
        this.gameObject.SetActive(true);
        rigidbody.velocity = new Vector3(_nowVelocity.x + _setVelocity, _nowVelocity.y, _nowVelocity.z);
    }

    public void DeActivate()
    {
        this.gameObject.SetActive(false);
    }
}
