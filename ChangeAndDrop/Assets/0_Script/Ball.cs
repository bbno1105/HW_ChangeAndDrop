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
        float randomVelocity = Random.Range(-2f, 2f);
        Vector3 nowSpeed = rigidbody.velocity;
        rigidbody.velocity = new Vector3(nowSpeed.x + randomVelocity, nowSpeed.y + randomVelocity, nowSpeed.z);

        StartCoroutine(ColliderSetting());
    }

    IEnumerator ColliderSetting()
    {
        // ���̾� �����ϰ�
        // �����Ǵ� ���� ���� ���� �ӵ� �ٸ��� �����ϱ�
        maxVelocityY = 0;
        yield return new WaitForSeconds(1f);
        maxVelocityY = 1f;
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

    public void Activate(Vector3 _position)
    {
        this.transform.position = _position;
        this.gameObject.SetActive(true);
        BallController.Instance.BallCount++;
    }

    public void DeActivate()
    {
        this.gameObject.SetActive(false);
        BallController.Instance.BallCount--;
    }
}
