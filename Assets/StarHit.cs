using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StarHit : MonoBehaviour
{
    public GameObject selectionMarker = null;

    private void OnTriggerEnter(Collider other)
    {         
    Debug.Log("Hit a star");

        if (selectionMarker != null)
        {
            Transform target = other.transform;

            GameObject selector = Instantiate(selectionMarker, other.transform);

            //other.transform
        }
    }
}
