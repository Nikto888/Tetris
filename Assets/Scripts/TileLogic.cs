using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic : MonoBehaviour
{
    [Tooltip("Color scaling factor.")]
    public float ColorScale = 1f;
    [Tooltip("Gradient color as object moves through space.")]
    public Gradient GradientColor;
    [Tooltip("The particle system to emit when cleared.")]
    public ParticleSystem m_particlesystem;

    Renderer m_renderer;

    Color MyColor = Color.black;
    
    bool Active = false;

    bool Paused = false;
    
    bool Clearing = false;
    float ClearClock = 0f;
    float ClearTime = 0f;

    int PositionX = 0;
    int PositionY = 0;
    int PositionZ = 0;

    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
        m_renderer.enabled = false;
    }

    void Update()
    {
        if (Clearing && !Paused)
        {
            ClearClock += Time.deltaTime;
            if (ClearClock < ClearTime)
            {
                m_renderer.material.SetColor("_EmissionColor", Color.Lerp(Color.black, Color.white, (ClearClock / ClearTime)));
            }
            else
            {
                ClearClock = 0f;
                m_renderer.material.DisableKeyword("_EMISSION");
                Clearing = false;
            }
        }
    }

    public void SetColor(Color input)
    {
        m_renderer.material.SetColor("_Color", input);
        MyColor = input;
    }

    public Color GetColor()
    {
        return MyColor;
    }

    public void Hide()
    {
        Active = false;
        m_renderer.enabled = false;
    }

    public void Show()
    {
        Active = true;
        m_renderer.enabled = true;
    }

    public void Clear(float time)
    {
        Clearing = true;
        m_renderer.material.EnableKeyword("_EMISSION");
        ClearTime = time;
    }

    public void Pause()
    {
        Paused = true;
    }

    public void Resume()
    {
        Paused = false;
    }

    public void SetPosition(int x, int y, int z)
    {
        PositionX = x;
        PositionY = y;
        PositionZ = z;
    }
}
