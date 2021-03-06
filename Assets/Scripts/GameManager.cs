﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Fading m_fading;

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

        DontDestroyOnLoad(gameObject);

        m_fading = gameObject.GetComponent<Fading>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }

        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            if (m_fading.enabled)
            {
                m_fading.enabled = false;
                Debug.Log("Fading disabled");
            }
        }
        else
        {
            if (!m_fading.enabled)
            {
                m_fading.enabled = true;
                m_fading.ResetFade();
                Debug.Log("Fading enabled");
            }
        }

        Debug.Log("Current scene: " + SceneManager.GetActiveScene().name);

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
