using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoScaleReversal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.parent.gameObject.transform.localScale.x == -1) {
            this.transform.localScale = new Vector3(-1, 1, 1);
        } else {
            this.transform.localScale = Vector3.one;
        }
	}
}
