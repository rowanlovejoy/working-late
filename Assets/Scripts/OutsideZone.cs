using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideZone : MonoBehaviour
{
    private const string LOCATIONNAME = "Outside";

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PlayerLocation = LOCATIONNAME;
        AudioManager.instance.Stop("InteriorAmbiance");
        AudioManager.instance.Play("ExteriorAmbiance");
    }
}
