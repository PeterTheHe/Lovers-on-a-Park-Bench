using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public bool trackX;
    public bool trackY;
    public float offsetY;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {

            transform.position = new Vector3((trackX) ? target.position.x : transform.position.x, (trackY) ? target.position.y + offsetY: transform.position.y, transform.position.z);

        }

    }
}
