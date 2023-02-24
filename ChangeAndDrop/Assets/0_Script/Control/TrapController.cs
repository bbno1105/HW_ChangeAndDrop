using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : SingletonBehaviour<TrapController>
{
    [SerializeField] Material[] trapMaterials;
    public Material[] TrapMaterials { get { return trapMaterials; } }

    void Awake()
    {
        initialize();
    }

    void initialize()
    {
        trapMaterials[0].color = GameData.BlueColor;
        trapMaterials[1].color = GameData.OrangeColor;
    }
}
