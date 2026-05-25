using UnityEngine;

public class WeldController : MonoBehaviour
{
    [Header("Welding Effects")]
    public ParticleSystem sparks;
    public Light arcLight;
    public TrailRenderer weldBead;

    void Start()
    {
        // Make sure everything is turned OFF when the game starts
        StopWelding();
    }

    void Update()
    {
        // Simulate pulling the real GMAW trigger using the Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWelding();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopWelding();
        }
    }

    void StartWelding()
    {
        arcLight.enabled = true;
        weldBead.emitting = true;
        if (!sparks.isPlaying) sparks.Play();
    }

    void StopWelding()
    {
        arcLight.enabled = false;
        weldBead.emitting = false; // Stops drawing, but leaves the old metal behind!
        if (sparks.isPlaying) sparks.Stop();
    }
}