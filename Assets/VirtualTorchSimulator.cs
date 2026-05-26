using UnityEngine;

public class VirtualTorchSimulator : MonoBehaviour
{
    [Header("SIMULATOR CONTROL VARIABLES")]
    public bool useVirtualHardware = true;

    [Header("LIVE SIMULATED TELEMETRY")]
    public float simulatedPitch = 45f;
    public float simulatedRoll = 90f;
    public float simulatedCTWD_mm = 15f;
    public float simulatedSpeed_IPM = 15f;
    public bool isTriggerPressed = false;

    void Update()
    {
        if (!useVirtualHardware) return;

        // 1. Simulate Trigger Press using Spacebar
        isTriggerPressed = Input.GetKey(KeyCode.Space);

        // 2. Simulate Pitch Adjustments (Gun Angle) using Up/Down Arrow Keys
        if (Input.GetKey(KeyCode.UpArrow)) simulatedPitch += 10f * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) simulatedPitch -= 10f * Time.deltaTime;
        simulatedPitch = Mathf.Clamp(simulatedPitch, 0f, 90f);

        // 3. Simulate CTWD Height changes using Mouse Scroll Wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        simulatedCTWD_mm += scrollInput * 50f;
        simulatedCTWD_mm = Mathf.Clamp(simulatedCTWD_mm, 5f, 40f);

        // 4. Simulate Travel Velocity shifts using Left/Right Arrow Keys
        if (Input.GetKey(KeyCode.RightArrow)) simulatedSpeed_IPM += 5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) simulatedSpeed_IPM -= 5f * Time.deltaTime;
        simulatedSpeed_IPM = Mathf.Clamp(simulatedSpeed_IPM, 0f, 30f);

        // LOG PRINT WINDOW FOR DEBUGGING
        if (isTriggerPressed)
        {
            Debug.Log($"[iARC Sim Log] Pitch: {simulatedPitch:F1}° | CTWD: {simulatedCTWD_mm:F1}mm | Speed: {simulatedSpeed_IPM:F1} IPM");
        }
    }
}