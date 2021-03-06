﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        AudioManager.instance.StopAll();
    }

    public void StartDemo()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void ExitDemo()
    {
        Application.Quit();
    }
}
