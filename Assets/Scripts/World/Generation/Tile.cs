using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public Transform player;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < player.transform.position.x - 300)
        {

            Destroy(gameObject);

        }

    }

}
