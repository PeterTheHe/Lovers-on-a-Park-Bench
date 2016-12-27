using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameLogic gameLogic;
    public float maxHealth;
    public float health;
    public bool target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (health < 1)
        {

            gameLogic.SendMessage("PlayerDead", target);

        }

        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        Color col = mySprite.color;
        col.a =  health / maxHealth;
        
        mySprite.color = col;

	}
}
