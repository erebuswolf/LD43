﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMenu : MonoBehaviour {
    [SerializeField]
    string nextScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && Time.timeSinceLevelLoad > 2) {
            SceneManager.LoadScene(nextScene);
        }
    }
}
