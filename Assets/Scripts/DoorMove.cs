using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    private DoorTrigger m_doorTrigger;
    private Animator m_animator;

    private void Awake()
    {
        m_doorTrigger = GameObject.Find("DoorTrigger").GetComponent<DoorTrigger>();
        m_animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (m_doorTrigger.playerInRange)
        {
            m_animator.SetBool("playerInRange", true);
            AudioManager.instance.Play("RevolvingDoor");
        }
        else
        {
            m_animator.SetBool("playerInRange", false);
            AudioManager.instance.Stop("RevolvingDoor");
        }
    }
}
