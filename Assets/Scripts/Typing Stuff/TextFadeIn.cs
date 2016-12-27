using UnityEngine;
using System.Collections;

public class TextFadeIn : MonoBehaviour {

    private bool fadeOut = false;

	// Use this for initialization
	void Start () {
	


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

        else
        {

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            Color col = sprite.color;
            col.a = Mathf.MoveTowards(col.a, fadeOut ? 0 : 1, Time.deltaTime);
            sprite.color = col;

            if (fadeOut)
            {

                if (col.a < 0.1f)
                {

                    Destroy(gameObject);

                }

            }


        }

	}

    void FadeOut()
    {

        fadeOut = true;

    }

}
