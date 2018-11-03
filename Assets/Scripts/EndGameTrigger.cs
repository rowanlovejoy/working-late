using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{

    private Fading m_fading;

    private void Awake()
    {
        m_fading = GameObject.Find("GameManager").GetComponent<Fading>();
    }

    void EndGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Demo ending shortly");
        float _fadeTime = m_fading.BeginFade(1);
        Invoke("EndGame", _fadeTime + 4.0f);
    }
}
