using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] COLORSTATE trapColor;

    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        Initialize();
    }

    void Initialize()
    {
        meshRenderer.material = TrapController.Instance.TrapMaterials[(int)trapColor];
    }

    void OnTriggerEnter(Collider other)
    {
        if(trapColor == BallController.Instance.BallColor)
        {

        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
