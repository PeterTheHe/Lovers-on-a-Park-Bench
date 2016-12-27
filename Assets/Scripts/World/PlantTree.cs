using UnityEngine;
using System.Collections;

public class PlantTree : MonoBehaviour {


    public Vector2 RandomOffset;

    // Use this for initialization
	void Start () {

        //Go to the ground

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 300, 1 << LayerMask.NameToLayer("Ground"));
        transform.position = new Vector3 (transform.position.x, hit.point.y + Random.Range(RandomOffset.x, RandomOffset.y), transform.position.z);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
