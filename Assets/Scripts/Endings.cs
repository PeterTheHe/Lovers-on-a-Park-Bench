using UnityEngine;
using System.Collections;

public class Endings : MonoBehaviour {

    public GameObject[] titles;
    public float[] showTimes;

    public int Level;

	// Use this for initialization
	void Start () {

        StartCoroutine(Show());

	}

    IEnumerator Show()
    {

        for (int i = 0; i < titles.Length; i ++)
        {

            yield return new WaitForSeconds(showTimes[i]);

            titles [i].SetActive(true);

            if (i < titles.Length - 1)
            {

                yield return new WaitForSeconds(showTimes[i+1] - showTimes[i]);
                titles[i].SetActive(false);

            }

            else
            {

                yield return new WaitForSeconds(3);
                titles[i].SetActive(false);


            }
            

        }

        Application.LoadLevel(Level);

    }

	// Update is called once per frame
	void Update () {
	
	}
}
