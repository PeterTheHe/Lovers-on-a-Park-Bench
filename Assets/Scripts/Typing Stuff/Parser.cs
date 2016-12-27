using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;


[System.Serializable]
public class Fragment
{

    public string key;
    public string text;
    public string functionCall; //when completed, what happens

}

[System.Serializable]
public class Sentence
{

    public List<Fragment> fragments;


}


public class Parser : MonoBehaviour {

    public TextAsset story;
    public List <Sentence> storySentences;

	// Use this for initialization
	void Awake () {

        string text = story.text;
        string [] sentences = text.Split('/');
        bool sentenceGood = false; 

        foreach (string sent in sentences)
        {


            Sentence sentence = new Sentence();
            sentence.fragments = new List<Fragment>();

            string[] bits = sent.Split('(');

            foreach (string bit in bits)
            {

                Fragment fragment = new Fragment();

                if (bit.Trim ().Length != 0)
                {

                    sentenceGood = true;
                    fragment.key = bit.Substring(0, 1);
      
                    string[] nibbles = bit.Split ('|'); //Much naming banter

                    if (nibbles.Length == 2)
                    {

                        fragment.text = nibbles [0].Substring(2);
                        fragment.functionCall = nibbles[1];
            
                    }
                    else
                    {

                        fragment.text = bit.Substring(2);
                        fragment.functionCall = "";
              
                    }

                    if (fragment.key.Trim () != "")
                    {
                        sentence.fragments.Add(fragment);
                   
                    }
                    else
                    {
                        sentenceGood = false;

                    }

                }

            

            }

            if (sentenceGood)
            {

                storySentences.Add(sentence);
            }

        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
