using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBloodPickup : Pickup {
    protected override bool PickupObject(PlayerController player) {
        return true;
    }

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BloodPickedUp() {
        animator.SetTrigger("BloodPickedUp");
    }
}
