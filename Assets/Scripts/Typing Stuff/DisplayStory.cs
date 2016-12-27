using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayStory : MonoBehaviour {

    public Parser parser;
    public GameLogic gameLogic;
    public GameObject StoryText;
    public GameObject ButtonText;
    public GameObject textStart;
    public GameObject buttonStart;

    public int currentSentence;
    public int currentFragment;

    public KeyCode currentKey;
    public float spacePerCharacter;
    public float spacePerTypeCharacter;

    public Transform instructionTransform;
    public GameObject Instructions;
    public GameObject moreInstructions;

    public GameObject Dave;
    public AudioClip[] clips;
    public AudioSource audio;
    public bool narrationOn;

    private bool _keyPressed;

	// Use this for initialization
	void Start () {

        narrationOn = true;
        GameObject textGO = Instantiate(StoryText, StoryText.transform.position - Vector3.right, Quaternion.identity) as GameObject;
        TextMesh text = textGO.GetComponent<TextMesh>();
        Color textColor = text.color;
        textColor.a = 0;
        text.color = textColor;
        text.text = "Hello World and everyone on it you puny little shits";

        float xBounds = textGO.GetComponent<Renderer>().bounds.size.x;

        spacePerCharacter = (xBounds / text.text.Length);

        Destroy(textGO);

        //AND FOR THE TYPES...

        spacePerTypeCharacter = 0;

        textGO = Instantiate(ButtonText, StoryText.transform.position - Vector3.right, Quaternion.identity) as GameObject;
        text = textGO.GetComponent<TextMesh>();
        textColor = text.color;
        textColor.a = 0;
        text.color = textColor;
        text.text = "Hello World and everyone on it you puny little shits";

        xBounds = textGO.GetComponent<Renderer>().bounds.size.x;

        spacePerTypeCharacter = (xBounds / text.text.Length);

        Destroy(textGO);

        audio = GetComponent<AudioSource>();

	}

    public void StartDisplay()
    {


        StartCoroutine(DisplaySentence());

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F2))
        {

            narrationOn = !narrationOn;

        }

	}

    IEnumerator DisplaySentence()
    {

        List<GameObject> storyTexts = new List<GameObject>();

         int x = -1;

        for (currentSentence = 0; currentSentence < parser.storySentences.Count; currentSentence ++)
        {

            x++;

            if (storyTexts.Count != 0)
            {

                yield return new WaitForSeconds(5);

                foreach (GameObject go in storyTexts)
                {

                    go.transform.SendMessage("FadeOut");
                    
                }

                storyTexts.Clear();
                yield return new WaitForSeconds(1);

            }

            int sentenceLength = 0;
            int linesRequired = 0;
            int currentCharacterTotal = 0;
            int characterIndent = -1;
            bool firstFragment = true;


            foreach (Fragment a in parser.storySentences [currentSentence].fragments)
            {

              

                sentenceLength += a.text.Length;
                linesRequired = Mathf.CeilToInt(sentenceLength / 115);  // The screen can take 115 chars


            }


            if (sentenceLength < 115)
            {

                characterIndent = Mathf.CeilToInt((115 - sentenceLength) / 2);

            }

            int currentTypeCharacterTotal = 0;
            
            List <GameObject> typeStuff = new List<GameObject>();

            bool isfirstFragment = true;

            foreach (Fragment a in parser.storySentences[currentSentence].fragments)
            {
               
                GameObject goButtonText = Instantiate(ButtonText, buttonStart.transform.position + Vector3.right * currentTypeCharacterTotal * (spacePerTypeCharacter + 0.8f), Quaternion.identity) as GameObject;
                goButtonText.transform.parent = buttonStart.transform;
                goButtonText.GetComponent<TextMesh>().text = a.key;
                currentTypeCharacterTotal += 1;
                typeStuff.Add(goButtonText);

            }

            float timeTaken = 0;
            int typeStuffIndex = 0;

            foreach (Fragment a in parser.storySentences[currentSentence].fragments)
            {

              
                string text = "";

                if (firstFragment)
                {

                    for (int i = 0; i < characterIndent; i++)
                    {

                        text += " ";

                    }

                

                }

                firstFragment = false;

                currentKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), a.key);
                Debug.Log(currentKey);




                while (!_keyPressed)
                {
                    if (Input.GetKeyDown(currentKey))
                    {

                        //horrible messy messy messy spaghetti

                        if (isfirstFragment && narrationOn)
                        {


                            isfirstFragment = false;
                            audio.PlayOneShot(clips[x]);

                        }

                        Debug.Log("AYY");
                        GameObject textThing = Instantiate(StoryText, textStart.transform.position + Vector3.right * currentCharacterTotal * (spacePerCharacter + 0.03f), Quaternion.identity) as GameObject;
                        textThing.transform.parent = textStart.transform;
                        text += a.text;
                        textThing.GetComponent<TextMesh>().text = text;
                        currentCharacterTotal += text.Length;
                        storyTexts.Add(textThing);

                        if (a.functionCall.Trim() != "")
                        {

                            Invoke(a.functionCall, 0);

                        }

                        gameLogic.score += Mathf.Clamp (Mathf.CeilToInt (10 - timeTaken), 0, 10);
                        typeStuff[typeStuffIndex].SendMessage("FadeOut");
                        timeTaken = 0;
                        typeStuffIndex++;
                        yield return 0;
                        break;

                    }
                //    print("Awaiting key input.");
                    timeTaken += Time.deltaTime;
                    yield return 0;

                }

            }

        }
   
  

    }

 

    void EnterDave ()
    {


        Dave.SetActive(true);
        StartCoroutine(ShowDaveInstructions());

    }

    IEnumerator ShowDaveInstructions()
    {

        yield return new WaitForSeconds(1);
        GameObject go = Instantiate(Instructions, instructionTransform.position, Quaternion.identity) as GameObject;
        go.transform.parent = instructionTransform;
        yield return new WaitForSeconds(7);
        go.SendMessage("FadeOut");
        yield return new WaitForSeconds(0.5f);
        go = Instantiate(moreInstructions, instructionTransform.position, Quaternion.identity) as GameObject;
        go.transform.parent = instructionTransform;
        yield return new WaitForSeconds(7);
        go.SendMessage("FadeOut");

    }

    void End()
    {


        //no one has died yet
        gameLogic.EndGameFade();

    }

}
