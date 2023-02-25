using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {

        }
    }


}
