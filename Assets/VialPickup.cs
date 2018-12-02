using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialPickup : Pickup {
    bool pickedUp = false;
    protected override bool PickupObject(PlayerController player) {
        if (!pickedUp && player.GetComponentInChildren<BloodManager>().CollectVial()) {
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
