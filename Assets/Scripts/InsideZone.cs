using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideZone : MonoBehaviour {

    private const string LOCATIONNAME = "Inside";

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PlayerLocation = LOCATIONNAME;
        Invoke("StopOutsideAudio", 0.75f);
        AudioManager.instance.Play("InteriorAmbiance");
    }

    void StopOutsideAudio()
    {
        AudioManager.instance.Stop("ExteriorAmbiance");
        AudioManager.instance.Stop("RevolvingDoor");
    }
}
