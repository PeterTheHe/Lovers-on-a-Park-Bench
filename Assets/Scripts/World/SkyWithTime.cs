using UnityEngine;
using System.Collections;

public class SkyWithTime : MonoBehaviour {


    public float gameLength; //seconds
    public TimeOfDay skyController;
    public GameLogic gameLogic;
    public bool sunset;
    [Range(0, 4)]
    public float target;

    float increment;

    // Use this for initialization
    void Start()
    {

        gameLogic = GetComponent<GameLogic>();
        skyController = GetComponent<TimeOfDay>();
   
    }

    // Update is called once per frame
    void Update()
    {

        increment = (skyController.maxBrightness - skyController.minBrightness) / (gameLength/10);


        if (!sunset)
        {

            if (skyController.brightness < target)
            {

                skyController.brightness = gameLogic.time * increment;
            }

        }
        else
        {


            if (skyController.brightness > target)
            {

                skyController.brightness = 4 - gameLogic.time * increment;
            }


        }

    }

}
