using UnityEngine;

public class WeldControllerPOC : MonoBehaviour
{
    [Header("Welding Effects Components")]
    public ParticleSystem sparksParticle;
    public ParticleSystem smokeParticle; // ADDED SMOKE
    public Light weldGlow;
    public AudioSource weldSound;

    [Header("Flicker Settings (Realism)")]
    public float minIntensity = 3.0f;
    public float maxIntensity = 8.0f;

    // Bright Arc Blue-White
    public Color weldColor = new Color(0.6f, 0.85f, 1.0f);

    void Start()
    {
        if (sparksParticle != null) sparksParticle.Stop();
        if (smokeParticle != null) smokeParticle.Stop();
        if (weldGlow != null)
        {
            weldGlow.enabled = false;
            weldGlow.color = weldColor;
        }
        if (weldSound != null) weldSound.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartWelding();
        else if (Input.GetKeyUp(KeyCode.Space)) StopWelding();

        if (Input.GetKey(KeyCode.Space) && weldGlow != null)
        {
            // Aggressive flicker for the electrical arc
            weldGlow.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }

    public void StartWelding()
    {
        if (sparksParticle != null) sparksParticle.Play();
        if (smokeParticle != null) smokeParticle.Play();
        if (weldGlow != null) weldGlow.enabled = true;
        if (weldSound != null && !weldSound.isPlaying) weldSound.Play();
    }

    public void StopWelding()
    {
        if (sparksParticle != null) sparksParticle.Stop();
        if (smokeParticle != null) smokeParticle.Stop();
        if (weldGlow != null) weldGlow.enabled = false;
        if (weldSound != null) weldSound.Stop();
    }
}