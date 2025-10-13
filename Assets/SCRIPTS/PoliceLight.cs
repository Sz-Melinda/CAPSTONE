using UnityEngine;

public class PoliceLight : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;
    public float flashSpeed = 2f; // flashes per second

    float timer;
    bool redOn;

    void Update()
    {
        timer += Time.deltaTime * flashSpeed;
        if (timer >= 1f)
        {
            timer = 0f;
            redOn = !redOn;
            redLight.enabled = redOn;
            blueLight.enabled = !redOn;
        }
    }
}