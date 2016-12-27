using UnityEngine;
using System.Collections;

public class WorldGeneration : MonoBehaviour {

    [System.Serializable]
    public class WorldUnit
    {

        public GameObject unit;
        public Vector2 offset;
        public bool canFlip;


    }

    [System.Serializable]
    public class PropUnit
    {

        public GameObject unit;
        public Vector2 offset;
        public bool canFlip;

    }



    public WorldUnit[] worldUnits; // tiles
    public PropUnit[] propUnits;
    public Vector2 currentPosition;
    public float groundDepth; //z axis value of ground
    private Transform player;



    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        currentPosition = new Vector2(-100, 0);
        Generate();

    }

    // Update is called once per frame
    void Update()
    {


        //When the player is reaching the end of the level
        if (player.position.x > currentPosition.x - 100)
        {

            Generate();

        }



    }

    void Generate()
    {

        for (int i = 0; i < 10; i++)
        {


            WorldUnit unit = worldUnits[Random.Range(0, worldUnits.Length)];
            currentPosition += unit.offset;


            Instantiate(unit.unit, new Vector3(currentPosition.x, currentPosition.y, groundDepth), Quaternion.identity);

            if (Random.Range(1, 3) == 2)
            {

                for (int j = 0; j < Random.Range(2, 12); j++)
                {

                    PropUnit pUnit = propUnits[Random.Range(0, propUnits.Length)];
                    Instantiate(pUnit.unit, new Vector3(currentPosition.x + Random.Range(-20, 20), currentPosition.y + pUnit.offset.y, Random.Range(-10, 10)), Quaternion.identity);

                }

            }

    
        }

    }
}
