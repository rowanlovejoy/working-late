using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOutside : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.Play("CityAmbiance");
    }

    private void OnTriggerExit(Collider other)
    {
        AudioManager.instance.Pause("CityAmbiance");
    }
}
