using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATE
{
    READY,
    INGAME,
    End
}

public enum COLORSTATE
{
    BLUE = 0,
    ORANGE
}

public class GameManager : SingletonBehaviour<GameManager>
{
    PLAYERSTATE playerState;
    public PLAYERSTATE PlayerState { get { return playerState; } }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        playerState = PLAYERSTATE.INGAME;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
