using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    [SerializeField]
    private DoorTrigger m_doorTrigger;

    private BoxCollider m_boxCollider;
    private MeshRenderer m_meshRenderer;

    private void Awake()
    {
        m_doorTrigger = GameObject.Find("DoorTrigger").GetComponent<DoorTrigger>();
        m_boxCollider = GetComponent<BoxCollider>();
        m_meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (m_doorTrigger.playerInRange && m_boxCollider.enabled && m_meshRenderer.enabled)
        {
            m_boxCollider.enabled = false;
            m_meshRenderer.enabled = false;
        }
        else if (!m_doorTrigger.playerInRange && !m_boxCollider.enabled && !m_meshRenderer.enabled)
        {
            m_boxCollider.enabled = true;
            m_meshRenderer.enabled = true;
        }
	}
}
