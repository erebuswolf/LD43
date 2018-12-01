using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPickup : MonoBehaviour {
    [SerializeField] int amount;

    bool pickedup;
    [SerializeField]
    BoxCollider2D trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateBloodPickup() {
        this.enabled = true;
        trigger.enabled = true;
    }

    private void PickupCheck(Collider2D other) {
        if (!this.enabled) {
            return;
        }
        BloodManager manager = other.GetComponentInParent<BloodManager>();
        if (manager && !pickedup) {
            manager.CollectBlood(amount);
            pickedup = true;
            SendMessageUpwards("BloodPickedUp");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PickupCheck(other);
    }

    private void OnTriggerStay2D(Collider2D other) {
        PickupCheck(other);
    }
}
