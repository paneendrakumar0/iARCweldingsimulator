[System.Serializable] // This tag is CRITICAL. It tells Unity "You are allowed to save this to a hard drive."
public class UserProfile
{
    public string userID;
    public string fullName;
    public string cohort; // e.g., "Morning Class 101"

    // Lifetime Stats
    public float totalWeldTime; // Total time spent in VR
    public int totalWeldsCompleted;
    public float averageScore;
}