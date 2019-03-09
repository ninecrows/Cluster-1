using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StarHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {         
    Debug.Log("Hit a star");
    }
}
