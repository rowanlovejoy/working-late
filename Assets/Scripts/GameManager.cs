using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private string m_playerLocation;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string PlayerLocation
    {
        get
        {
            return m_playerLocation;
        }

        set
        {
            if (value != null && value != "")
            {
                m_playerLocation = value;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
