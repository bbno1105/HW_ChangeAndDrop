using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    MeshRenderer meshRenderer;
    TrailRenderer trailRenderer;
    Rigidbody rigidbody;
    Collider collider;

    float maxVelocityY = 1f;
    float minVelocityY = -3f; 
    float maxVelocityX = 3f;
    float minVelocityX = -3f;

    float limitPositionY;
    [SerializeField] float createPositionY;
    public float CreatePositionY { get { return createPositionY; } set { createPositionY = value; } }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        meshRenderer.material = BallController.Instance.BallMaterial;
        trailRenderer.material = BallController.Instance.TrailMaterial;
    }

    void OnEnable()
    {
        gameObject.layer = 8;
        gameObject.tag = "Ball";
        limitPositionY = this.transform.position.y;

        collider.isTrigger = false;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (PlayerController.Instance.PlayerState)
        {
            case PLAYERSTATE.INGAME:
                if (collision.gameObject.layer == 0)
                {
                    gameObject.layer = 7;
                }
                break;

            default:
                break;
        }

    }

    void Update()
    {
        switch (PlayerController.Instance.PlayerState)
        {
            case PLAYERSTATE.INGAME:
                LimitSpeed();
                LimitArea();
                break;

            default:
                if (transform.position.y < -100)
                {
                    DeActivate();
                }
                break;
        }
        
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

    void LimitArea()
    {
        Vector3 position = transform.position;
        if (position.x < -1.5f)
        {
            transform.position = new Vector3(-1.5f, position.y, position.z);
        }
        else if(position.x > 1.5f)
        {
            transform.position = new Vector3(1.5f, position.y, position.z);
        }

        if(position.y > limitPositionY)
        {
            transform.position = new Vector3(position.x, limitPositionY, position.z);
        }
    }

    public void Activate(Vector3 _position, Vector3 _nowVelocity ,float _setVelocity)
    {
        CreatePositionY = _position.y - 1;

        transform.position = _position;

        gameObject.SetActive(true);
        rigidbody.velocity = new Vector3(_nowVelocity.x + _setVelocity, _nowVelocity.y, _nowVelocity.z);
    }

    public void DeActivate(bool _isDistroy = false)
    {
        if(_isDistroy) --BallController.Instance.BallCount;
        gameObject.SetActive(false);
    }

    public void PopBall()
    {
        collider.isTrigger = true;
        rigidbody.velocity = new Vector3(Random.Range(-2f, 2f), Random.Range(6f, 12f), Random.Range(-2f, 1f));
    }
}
