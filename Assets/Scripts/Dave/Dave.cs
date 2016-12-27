using UnityEngine;
using System.Collections;

public class Dave : MonoBehaviour {

    public int currentWeapon;
    public AudioSource audio;

    public GameLogic gameLogic;
    public Transform muzzle;
    public GameObject lightning;
    public int lightningCost;
    public AudioClip lighningSound;

    public GameObject meteor;
    public float meteorReload;
    public int meteorCost;
    private bool canShootMeteor;
    public AudioClip meteorSound;
         

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            currentWeapon = 1;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            currentWeapon = 2;
        }

        transform.rotation = Quaternion.Euler(0, 0, Time.timeSinceLevelLoad * 50);

        if (Input.GetButtonDown("Fire") && gameLogic.score - lightningCost > -1 && currentWeapon == 1)
        {

            GameObject go = Instantiate(lightning, muzzle.position, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(muzzle.right * 1000);
            gameLogic.score -= lightningCost;
            audio.PlayOneShot(lighningSound);

        }

        if (Input.GetButtonDown("Fire") && gameLogic.score - meteorCost > -1 && currentWeapon == 2)
        {

            GameObject go = Instantiate(meteor, muzzle.position, Quaternion.identity) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(muzzle.right * 10000);
            gameLogic.score -= meteorCost;
            canShootMeteor = false;
            audio.PlayOneShot(meteorSound);
            StartCoroutine(ReloadMeteor());
         

        } 
	
	}

    IEnumerator ReloadMeteor()
    {

        yield return new WaitForSeconds(meteorReload);
        canShootMeteor = true;

    }

}
