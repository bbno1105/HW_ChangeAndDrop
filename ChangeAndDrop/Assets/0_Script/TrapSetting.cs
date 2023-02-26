using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetting : MonoBehaviour
{
    // TODO : 데이터에서 받아오기
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
        // TODO : TrapColor를 데이터에서 받아오기
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
    /// 이동 트랩의 처리
    /// </summary>
    /// <param name="_moveRight">true : 오른쪽으로 이동, false : 왼쪽으로 이동</param>
    /// <param name="_moveSpeed">이동속도</param>
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
    /// 트랩 위치 설정
    /// </summary>
    /// <param name="_positionX">범위 : - 3.1f ~ 3.1f </param>
    void TrapPositon(float _positionX)
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(_positionX, position.y, position.z);
    }
}
