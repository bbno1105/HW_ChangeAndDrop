using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    MeshRenderer meshRenderer;
    TrailRenderer trailRenderer;
    Rigidbody rigidbody;
    Collider collider;

    void Awake()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        trailRenderer = this.GetComponent<TrailRenderer>();
        rigidbody = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<Collider>();

        meshRenderer.material = BallController.Instance.BallMaterial;
        trailRenderer.material = BallController.Instance.TrailMaterial;
    }

    void OnEnable()
    {
        //StartCoroutine(ColliderSetting());
    }

    IEnumerator ColliderSetting()
    {
        float randomVelocityX = Random.Range(-1f, 1f);
        Vector3 nowSpeed = rigidbody.velocity;
        rigidbody.velocity = new Vector3(nowSpeed.x + randomVelocityX, nowSpeed.y, nowSpeed.z);
        collider.isTrigger = true;
        yield return new WaitForSeconds(1f);
        collider.isTrigger = false;
    }

    void Update()
    {
        LimitSpeed();
    }

    void LimitSpeed()
    {
        Vector3 nowSpeed = rigidbody.velocity;
        if (nowSpeed.x > 3)
        {
            rigidbody.velocity = new Vector3(3, nowSpeed.y, nowSpeed.z);
        }
        if (nowSpeed.x < -3)
        {
            rigidbody.velocity = new Vector3(-3, nowSpeed.y, nowSpeed.z);
        }
        if (nowSpeed.y < -3f)
        {
            rigidbody.velocity = new Vector3(nowSpeed.x, -3f, nowSpeed.z);
        }
        if (nowSpeed.y > 1f)
        {
            rigidbody.velocity = new Vector3(nowSpeed.x, 1f, nowSpeed.z);
        }
    }

    public void Active(Vector3 _position)
    {
        this.transform.position = _position;
        this.gameObject.SetActive(true);
    }
}
