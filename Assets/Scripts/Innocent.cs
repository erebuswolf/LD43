using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innocent : KillableActor {

    [SerializeField] GameObject sprite;

	// Use this for initialization
	new void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ChangeSpriteLocation() {
        sprite.transform.localPosition = new Vector3(0.452f, 0);
    }
}
