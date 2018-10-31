using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideZone : MonoBehaviour {

    private const string LOCATIONNAME = "Inside";

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PlayerLocation = LOCATIONNAME;
    }
}
