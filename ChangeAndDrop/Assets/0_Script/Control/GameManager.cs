using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] int nowStage;
    public int NowStage { get { return nowStage; } set { nowStage = value; } }
    
    public Queue<Box> boxList = new Queue<Box>();

    [SerializeField] Box nowBox;
    public Box NowBox { get { return nowBox; } set { nowBox = value; } }

    void Awake()
    {

    }

    public void Initialize()
    {

    }

    void Update()
    {
        
    }

    public bool NextBox()
    {
        if (boxList.Count <= 0) return false;
        nowBox = boxList.Dequeue();
        return true;
    }
}
