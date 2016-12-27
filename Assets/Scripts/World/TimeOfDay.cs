using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{

    [Range(0, 4)]
    public float brightness;
    public Transform sky;
    public Light sun;
    public float minBrightness;
    public float maxBrightness;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //This is because 40 is midnight and -40 is sunset

        float yOffset = (brightness - 2) * 18;

        sky.localPosition = new Vector3(0, yOffset, sky.localPosition.z);
        sun.intensity = (minBrightness + (maxBrightness - minBrightness) / 10 * brightness);

    }
}
