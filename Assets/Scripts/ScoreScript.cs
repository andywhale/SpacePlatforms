using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    GameManager gameManager;
    string[] messages;
    const int NUMBEROFLEVELS = 40;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        messages = new string[NUMBEROFLEVELS];
        messages[0] = "[NASA] You played space invaders kid ... this is going to be nothing like that ... get to a platform ... you fall off and drift into space ... there will be no quick death";
        messages[1] = "[NASA] Well done ... you've made it to the first platform ... I'm not going to feed you a lie ...";
        messages[2] = "[NASA] - RADIO SILENCE -";

        for (int i = 3; i < NUMBEROFLEVELS; i++)
        {
            messages[i] = "[NASA] Platform " + i.ToString() + " keep going";
        }

        messages[6] = "[NASA] Platform 6 ... you think platform hopping is tedious try having to announce it";
    }

	void FixedUpdate () {
        GetComponent<Text>().text = messages[gameManager.GetLevel()];
    }
}
