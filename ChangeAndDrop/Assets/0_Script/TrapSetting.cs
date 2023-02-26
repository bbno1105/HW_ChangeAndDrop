using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetting : MonoBehaviour
{
    // TODO : �����Ϳ��� �޾ƿ���
    [SerializeField] float trapStartPosition;
    public float TrapStartPosition { get { return trapStartPosition; } set { trapStartPosition = value; } }
    [SerializeField] bool isMoveTrap;
    public bool IsMoveTrap { get { return isMoveTrap; } set { isMoveTrap = value; } }
    [SerializeField] bool moveRight;
    public bool MoveRight { get { return moveRight; } set { moveRight = value; } }
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        // TODO : TrapColor�� �����Ϳ��� �޾ƿ���
        TrapPositon(trapStartPosition);
    }


    void Update()
    {
        if (IsMoveTrap)
        {
            MoveTrap(MoveRight, MoveSpeed);
        }
    }

    /// <summary>
    /// �̵� Ʈ���� ó��
    /// </summary>
    /// <param name="_moveRight">true : ���������� �̵�, false : �������� �̵�</param>
    /// <param name="_moveSpeed">�̵��ӵ�</param>
    void MoveTrap(bool _moveRight, float _moveSpeed)
    {
        Vector3 position = transform.position;
        if (_moveRight)
        {
            float movePositionX = position.x + _moveSpeed * Time.deltaTime;
            if (movePositionX >= 3.1f) movePositionX = -3.1f; // Loop
            transform.position = new Vector3(movePositionX, position.y, position.z);
        }
        else
        {
            float movePositionX = position.x - _moveSpeed * Time.deltaTime;
            if (movePositionX <= -3.1f) movePositionX = 3.1f; // Loop
            transform.position = new Vector3(movePositionX, position.y, position.z);
        }
    }

    /// <summary>
    /// Ʈ�� ��ġ ����
    /// </summary>
    /// <param name="_positionX">���� : - 3.1f ~ 3.1f </param>
    void TrapPositon(float _positionX)
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(_positionX, position.y, position.z);
    }
}
