using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeldResult
{
    public string resultID;
    public string studentID;
    public string assignmentID;
    public string timestamp;

    // Final calculated grades
    public float finalScore;
    public float totalConsumableCost;

    // The actual 3D recording (30 frames per second of data)
    public List<TelemetryFrame> telemetryData = new List<TelemetryFrame>();
}

[System.Serializable]
public struct TelemetryFrame
{
    public float timeSeconds;
    public Vector3 torchPosition; // X, Y, Z coordinates for the 3D Replay drawing
    public float workAngle;
    public float travelAngle;
    public float travelSpeed;
    public float ctwd;
    public bool isArcActive;
}