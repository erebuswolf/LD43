using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKeyReader : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        bool quit = Input.GetKeyDown(KeyCode.Escape);
        if (quit) {
            Application.Quit();
        }
        bool start = Input.GetKeyDown(KeyCode.Space);
        if (start) {
            SceneManager.LoadScene("Level1");
        }
    }
}
