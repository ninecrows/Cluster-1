using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StarHit : MonoBehaviour
{
    public GameObject selectionMarker = null;
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackPadAction;

    private void Update()
    {
        if (trackPadAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }

        if (trackPadAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
        }
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

    private void OnTriggerEnter(Collider other)
    {         
    Debug.Log("Hit a star");

        if (selectionMarker != null)
        {
            Transform target = other.transform;

            GameObject selector = Instantiate(selectionMarker, other.transform);

            //CVRSystem.TriggerHapticPulse(0, 0, 100);  //HandRole.LeftHand);

            //ViveInput.TriggerHapticPulse(HandRole.LeftHand);
            //other.transform

            Pulse(0.05f, 800, 25, SteamVR_Input_Sources.RightHand);
        }
    }
}
