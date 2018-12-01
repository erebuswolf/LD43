using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : KillableActor {

    Movement movement;
	// Use this for initialization
	new void Start () {
        base.Start();
        movement = GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!dead) { 
            movement.SetValues(false, false, false, true);
        }
    }
}
