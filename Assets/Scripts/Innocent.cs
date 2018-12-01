using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innocent : KillableActor {

    [SerializeField] GameObject sprite;

    Movement movement;
	// Use this for initialization
	new void Start () {
        base.Start();
        movement = GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!dead) {
            movement.SetValues(false, true, false, false);
        } else {
            movement.SetValues(false, false, false, false);
        }
    }
    
    public void ChangeSpriteLocation() {
        sprite.transform.localPosition = new Vector3(0.452f, 0);
    }
}
