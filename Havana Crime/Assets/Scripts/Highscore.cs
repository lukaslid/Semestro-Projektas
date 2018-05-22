using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class Highscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string highscore = File.ReadAllText("highscore.txt");
        GameObject.Find("Highscore").GetComponent<TextMesh>().text = (highscore.ToString());
    }
	
	// Update is called once per frame

}
