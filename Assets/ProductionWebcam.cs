using UnityEngine;

public class ProductionWebcam : MonoBehaviour
{
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("UNITY: Zero cameras detected!");
            return;
        }

        string targetCamera = devices[0].name; // Default fallback

        // Loop through all cameras and find the Logitech
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("UNITY SEES: " + devices[i].name);

            // If the name has "Logi" or "HD" in it, lock onto it!
            if (devices[i].name.ToLower().Contains("logi") || devices[i].name.ToLower().Contains("hd"))
            {
                targetCamera = devices[i].name;
            }
        }

        Debug.Log("TURNING ON: " + targetCamera);
        WebCamTexture labCamera = new WebCamTexture(targetCamera);
        GetComponent<Renderer>().material.mainTexture = labCamera;
        labCamera.Play();
    }
}