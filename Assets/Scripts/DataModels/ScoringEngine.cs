using UnityEngine;

public static class ScoringEngine
{
    // The exact scoring tolerances (You can adjust these later)
    private const float ANGLE_TOLERANCE = 5f; // +/- 5 degrees is a perfect score
    private const float SPEED_TOLERANCE = 2f; // +/- 2 IPM is perfect
    private const float CTWD_TOLERANCE = 0.5f; // +/- 0.5 cm is perfect

    public static float GradeSingleFrame(TelemetryFrame studentFrame, WeldAssignment assignment)
    {
        float workAngleScore = CalculateParameterScore(studentFrame.workAngle, assignment.targetWorkAngle, ANGLE_TOLERANCE, 15f);
        float travelAngleScore = CalculateParameterScore(studentFrame.travelAngle, assignment.targetTravelAngle, ANGLE_TOLERANCE, 15f);
        float speedScore = CalculateParameterScore(studentFrame.travelSpeed, assignment.targetTravelSpeed, SPEED_TOLERANCE, 5f);
        float ctwdScore = CalculateParameterScore(studentFrame.ctwd, assignment.targetCTWD, CTWD_TOLERANCE, 2f);

        // Average them together for this specific split-second of welding
        return (workAngleScore + travelAngleScore + speedScore + ctwdScore) / 4f;
    }

    private static float CalculateParameterScore(float actual, float target, float perfectTolerance, float failTolerance)
    {
        float difference = Mathf.Abs(actual - target);

        if (difference <= perfectTolerance) return 100f; // Perfect!
        if (difference >= failTolerance) return 0f; // Complete failure

        // Math to calculate partial credit (e.g., 85 points)
        float score = 100f * (1f - ((difference - perfectTolerance) / (failTolerance - perfectTolerance)));
        return Mathf.Clamp(score, 0f, 100f);
    }
}