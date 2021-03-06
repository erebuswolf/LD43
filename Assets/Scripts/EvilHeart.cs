﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilHeart : Pickup {
    [SerializeField]
    int DarkHealth;

    bool pickedUp = false;

    protected override bool PickupObject(PlayerController player) {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        if(!pickedUp && player.GetComponentInChildren<Health>().AddDarkHealth(DarkHealth)) {

            pickedUp = true;
            return true;
        }
        return false;
    }

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
