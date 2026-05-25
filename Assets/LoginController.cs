using UnityEngine;
using TMPro; // This is required to talk to TextMeshPro UI elements
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [Header("UI Connections")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;

    void Start()
    {
        // This tells the button to run the "AttemptLogin" function when clicked
        loginButton.onClick.AddListener(AttemptLogin);
    }

    public void AttemptLogin()
    {
        // Grab the text the user typed in
        string enteredUsername = usernameInput.text;
        string enteredPassword = passwordInput.text;

        // Print it to the Unity Console so we know it works!
        Debug.Log("Login Button Clicked!");
        Debug.Log("Username typed: " + enteredUsername);
        Debug.Log("Password typed: " + enteredPassword);
    }
}