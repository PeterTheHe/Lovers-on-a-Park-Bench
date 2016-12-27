using UnityEngine;
using System.Collections;

public class ExplodeOnImpact : MonoBehaviour {

    public GameObject explosion;
    public float range = 10;
    public float force = 5;
    public bool splashDamage;
    public AudioClip explosionSound;
    public AudioSource audio;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    bool dealtDamage;

    void OnCollisionEnter2D(Collision2D collision)
    {

        audio.PlayOneShot(explosionSound);

        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, range))
        {

            if (col.GetComponent<Rigidbody2D>())
            {

                //TODO: ADD DISTANCE EFFECT
                col.GetComponent<Rigidbody2D>().AddForce(((col.transform.position - transform.position).normalized * force) + Vector3.up * force);


            }

            
                if (splashDamage)
                {

                    if (col.GetComponent<PlayerHealth>())
                    {

                        col.GetComponent<PlayerHealth>().health -= 5;

                    }

                }

        }

        if (collision.collider.GetComponent<PlayerHealth>())
        {

            if (!dealtDamage)
            {
                collision.collider.GetComponent<PlayerHealth>().health -= 10;
                dealtDamage = true;
            }
        }

       

        Instantiate(explosion, transform.position, Quaternion.identity);
        transform.DetachChildren();
        StartCoroutine(Die());

    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }

}
