using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    [Tooltip("Value that the slider cahnges")]
    public string Attribute = "";
    [Tooltip("The GameLogic entity for the game.")]
    public GameObject Controller;
    [Tooltip("The reference to the active slider.")]
    public Slider m_slider;
    void Start()
    {
        if (Attribute == "Camera Speed")
        {
            GameLogic controllerLogic = Controller.GetComponent<GameLogic>() as GameLogic;
            m_slider.value = controllerLogic.GetRotationSpeed();
        }
        else if (Attribute == "Zoom Speed")
        {
            GameLogic controllerLogic = Controller.GetComponent<GameLogic>() as GameLogic;
            m_slider.value = controllerLogic.GetZoomSpeed();
        }
        else
        {
            Debug.Log("Attribute not set to a valid value.");
        }
    }

    void Update()
    {
        
    }
}
