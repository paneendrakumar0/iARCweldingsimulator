using UnityEngine;
using TMPro; // We will use this for the UI Text later

p
    // This triggers when the torch reaches the end and leaves the Box Collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Torch") && isWelding)
        {
            isWelding = false;
            CalculateFinalScore(Time.time - startTime);
        }
    }

    private void CalculateFinalScore(float timeTaken)
    {
        // 1. Calculate Speed in mm/s
        float distanceMM = weldLengthMeters * 1000f;
        float actualSpeed = distanceMM / timeTaken;

        // 2. Calculate the Score (Starts at 100, loses points for being too fast/slow)
        float speedDifference = Mathf.Abs(perfectSpeedMMS - actualSpeed);
        float finalScore = 100f - (speedDifference * 8f); // Subtract 8 points for every 1 mm/s off
        finalScore = Mathf.Clamp(finalScore, 0f, 100f); // Keep score between 0 and 100

        // 3. Update the UI
        if (finalScore >= 80f)
        {
            scoreDisplay.text = $"PERFECT WELD!\nScore: {finalScore:F0}/100\nSpeed: {actualSpeed:F1} mm/s";
            scoreDisplay.color = Color.green;
        }
        else
        {
            scoreDisplay.text = $"POOR WELD.\nScore: {finalScore:F0}/100\nSpeed: {actualSpeed:F1} mm/s";
            scoreDisplay.color = Color.red;
        }
    }
}