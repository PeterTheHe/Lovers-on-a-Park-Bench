using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameLogic : MonoBehaviour {


    public bool inGame;
    public float scrollSpeed;

    public TextMesh startText;
    public AudioSource audio;
    public int score;
    public TextMesh scoreText;
    public DisplayStory displayStory;
    public GameObject fader;
    public GameObject typeInstruction;
    public Transform instructionPosition;
    public GameObject talkStuff;

    public int girlEnding = 4;
    public int boyEnding = 3;

    public float time;
   

	// Use this for initialization
	void Start () {


        if (audio == null)
        {

            audio = GetComponent<AudioSource>();

        }

	}
	
	// Update is called once per frame
	void Update () {

        if (inGame)
        {

            time += Time.deltaTime ;
           

        }

        else
        {


            if (Input.GetMouseButtonDown(0))
            {
                
                inGame = true;
                startText.gameObject.SetActive(false);
                audio.Play();
                StartCoroutine(ShowInstruction());
                displayStory.StartDisplay();
            }


        }

        scoreText.text = "Points: " + score.ToString();

	}

    IEnumerator ShowInstruction()
    {

        GameObject go = Instantiate(typeInstruction, instructionPosition.position, Quaternion.identity) as GameObject;
        go.transform.parent = instructionPosition;
        yield return new WaitForSeconds(4);

        go.SendMessage("FadeOut");

    }

    public void PlayerDead(bool isTarget)
    {

        inGame = false;

        if (!isTarget)
        {

            //killed girl
            EndGameFade();
            StartCoroutine(fadeOutAfterSeconds(girlEnding));

        }

        else
        {

            //killed guy
            EndGameFade();
            StartCoroutine(fadeOutAfterSeconds(boyEnding));

        }

    }

    public void EndGameFade()
    {


        StartCoroutine(fadeOutAfterSeconds());
    }



    IEnumerator fadeOutAfterSeconds()
    {

        yield return new WaitForSeconds(7);
        Instantiate(fader, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        talkStuff.SetActive(true);
    }

    IEnumerator fadeOutAfterSeconds(int Level)
    {

        yield return new WaitForSeconds(3);
        Instantiate(fader, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        Application.LoadLevel(Level);

    }


}
