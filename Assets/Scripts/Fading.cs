using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    [SerializeField]
    private Texture2D m_fadeOutTexture;
    [SerializeField]
    private float m_fadeSpeed = 0.8f;
    [SerializeField]
    private int m_drawDepth = -1000;
    [SerializeField]
    private float m_alpha = 0.0f;
    [SerializeField]
    private int m_fadeDir = -1;

    private void OnGUI()
    {
        m_alpha += m_fadeDir * m_fadeSpeed * Time.deltaTime;
        m_alpha = Mathf.Clamp01(m_alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, m_alpha);
        GUI.depth = m_drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_fadeOutTexture);
    }

    public float BeginFade(int _direction)
    {
        m_fadeDir = _direction;
        return m_fadeSpeed;
    }
}
