[System.Serializable]
public class WeldAssignment
{
    public string assignmentID;
    public string assignmentName;
    public string weldType; // e.g., "GMAW"
    public string material; // e.g., "Carbon Steel 1/4 inch"
    public string jointType; // e.g., "T-Joint"

    // The Target Parameters (The Teacher's rules)
    public float targetWorkAngle = 45f;
    public float targetTravelAngle = 15f;
    public float targetTravelSpeed = 12f; // Inches Per Minute
    public float targetCTWD = 1.5f; // cm
}