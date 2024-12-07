using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickerLight; // Assign your light here
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 1.5f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // Speed of the flicker (lower is faster)

    private float time = 0f;

    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= flickerSpeed)
        {
            // Randomly adjust the intensity within the range
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            time = 0f; // Reset the timer
        }
    }
}
