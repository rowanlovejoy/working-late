using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private string m_playerLocation;
    private string m_prevPlayerLocation;

    public delegate void LocationChange();
    public static event LocationChange LocationChanged;

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
            if (value != null && value != "" && value != m_playerLocation)
            {
                m_prevPlayerLocation = m_playerLocation;
                m_playerLocation = value;
                if (LocationChanged != null)
                {
                    LocationChanged();
                }
            }
        }
    }

    public string PrevPlayerLocation
    {
        get
        {
            return m_prevPlayerLocation;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
