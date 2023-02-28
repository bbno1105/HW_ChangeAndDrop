using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] int nowStage;
    public int NowStage { get { return nowStage; } set { nowStage = value; } }
    
    Queue<Box> boxList = new Queue<Box>();
    [SerializeField] Box[] box;
    [SerializeField] Box nowBox;
    public Box NowBox { get { return nowBox; } set { nowBox = value; } }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        NowStage = 0;

        for (int i = 0; i < box.Length; i++)
        {
            boxList.Enqueue(box[i]);
        }
        nowBox = boxList.Dequeue();
    }

    void Update()
    {
        
    }

    public bool NextBox()
    {
        if (boxList.Count <= 0) return false;
        nowBox = boxList.Dequeue();
        PlayerController.Instance.Initialize();
        return true;
    }
}
