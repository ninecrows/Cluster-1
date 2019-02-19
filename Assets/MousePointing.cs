using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointing : MonoBehaviour
{
    private GameObject lastHit = null;
    private Color lastColor;
    Vector3 lastScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetMouseButtonDown(0)

        Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        // ray = GvrBasePointer.PointerRay;

        //GvrLaserPointerImpl laserPointerImpl = (GvrLaserPointerImpl)GvrPointerManager.Pointer;

        // Look to see if we hit something and if that something was a star. 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Find the game object that we hit.
            Transform target = hit.transform;
            GameObject myObject = target.gameObject;

            if (lastHit != null && myObject != lastHit)
            {
                lastHit.GetComponent<Renderer>().material.color = lastColor;
                lastHit.transform.localScale = lastScale;
                lastHit = null;
            }

            if (myObject.tag == "Star")
            {
                if (lastHit != null)
                {
                    lastHit.GetComponent<Renderer>().material.color = lastColor;
                    lastHit.transform.localScale = lastScale;
                }

                // ...and the C# object that contains its information
                StellarInformation myStar = myObject.GetComponent<StellarInformation>();

                lastColor = myObject.GetComponent<Renderer>().material.color;
                lastScale = myObject.transform.localScale;

                myObject.GetComponent<Renderer>().material.color = Color.white;
                
                    myObject.transform.localScale *= 8;
                
                // Remember this object so that we can put it back to normal when we leave it.
                lastHit = myObject;
            }
            else
            {
                if (lastHit != null)
                {
                    lastHit.GetComponent<Renderer>().material.color = lastColor;
                    lastHit.transform.localScale = lastScale;
                    lastHit = null;
                }
            }
        }
        else
        {
            if (lastHit != null)
            {
                lastHit.GetComponent<Renderer>().material.color = lastColor;
                lastHit.transform.localScale = lastScale;
                lastHit = null;
            }
        }
    }
}
