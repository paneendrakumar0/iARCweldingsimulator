using UnityEngine;
using UnityEngine.UI;

public class WeldingHelmetLogic : MonoBehaviour
{
    [Header("UI Elements")]
    public Image darkeningFilter;

    [Header("3D Elements (Sparks, Arc, etc.)")]
    public GameObject virtualWeldEffects;

    [Header("Lens Settings")]
    [Tooltip("0 = fully clear, 1 = pitch black. 0.95 acts like Shade 10 glass.")]
    [Range(0f, 1f)]
    public float darkAlpha = 0.95f;
    [Range(0f, 1f)]
    public float clearAlpha = 0.0f;

    void Start()
    {
        // Start the simulation with a clear lens and sparks off
        SetLensState(false);
    }

    void Update()
    {
        // HARDWARE PLACEHOLDER: 
        // Later, we will replace this Spacebar input with the ESP32 serial data.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetLensState(true); // Trigger pulled -> Darken lens, ignite arc
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SetLensState(false); // Trigger released -> Clear lens, stop arc
        }
    }

    void SetLensState(bool isWelding)
    {
        // 1. Change the transparency (Alpha) of the black tint
        if (darkeningFilter != null)
        {
            Color tintColor = darkeningFilter.color;
            tintColor.a = isWelding ? darkAlpha : clearAlpha;
            darkeningFilter.color = tintColor;
        }

        // 2. Turn the 3D glowing effects on or off
        if (virtualWeldEffects != null)
        {
            virtualWeldEffects.SetActive(isWelding);
        }
    }
}