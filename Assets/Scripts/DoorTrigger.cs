using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool playerInRange = false;
    [SerializeField]
    private bool m_triggerEnabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (m_triggerEnabled)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_triggerEnabled)
        {
            playerInRange = false;
        }
    }

    public void DisableTrigger()
    {
        m_triggerEnabled = false;
        playerInRange = false;
    }

}
