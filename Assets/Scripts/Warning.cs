using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {

    public int linkLevel;
    public bool fadeOut;
    public int time;

	// Use this for initialization
	void Start () {

        Invoke("LoadLevel", time);

	}

    void LoadLevel()
    {

        Application.LoadLevel(linkLevel);

    }
	
	// Update is called once per frame
	void Update () {


        if (GetComponent<TextMesh>())
        {

            TextMesh text = GetComponent<TextMesh>();
            Color col = text.color;
            col.a = Mathf.MoveTowards(col.a, fadeOut ? 0 : 1, Time.deltaTime);
            text.color = col;

            if (fadeOut)
            {

                if (col.a < 0.1f)
                {

                    Destroy(gameObject);

                }

            }

        }

	}
}
