using UnityEngine;

public class AutoWeldTrigger : MonoBehaviour
{
    [Header("Tracking Targets")]
    public Transform gunTip;
    public Transform weldPath;

    [Header("Trigger Settings")]
    public float triggerDistance = 0.03f; // 3 centimeters

    private bool isWelding = false;

    void Update()
    {
        // Calculate the exact distance between the gun tip and the path
        float distance = Vector3.Distance(gunTip.position, weldPath.position);

        // If close enough AND not currently welding -> START WELD
        if (distance <= triggerDistance && !isWelding)
        {
            isWelding = true;
            Debug.Log("🔥 ARC STRUCK! Distance is " + distance.ToString("F3") + "m. WELDING ON.");
        }
        // If pulled away AND currently welding -> STOP WELD
        else if (distance > triggerDistance && isWelding)
        {
            isWelding = false;
            Debug.Log("❌ ARC BROKEN! Distance is " + distance.ToString("F3") + "m. WELDING OFF.");
        }
    }
}