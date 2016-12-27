using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float thrust;
    public Rigidbody2D rigidbody;
    public GameLogic gameLogic;


    // Use this for initialization
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (gameLogic.inGame)
        {

            if (rigidbody.velocity.x < gameLogic.scrollSpeed)
            {

                rigidbody.AddForce(Vector3.right * ((GetComponent<SpriteRenderer>().isVisible) ? thrust : thrust * 100));

            }

            else
            {

                rigidbody.velocity = new Vector3((GetComponent<SpriteRenderer>().isVisible) ? gameLogic.scrollSpeed : gameLogic.scrollSpeed * 6, (GetComponent<SpriteRenderer>().isVisible) ? rigidbody.velocity.y:-100);
                
            }

            if (Vector2.Distance(transform.position, Camera.main.transform.position) > 100)
            {

                transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);

            }

        }

    }
}
