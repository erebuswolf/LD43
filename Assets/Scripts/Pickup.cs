using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {

    protected Animator animator;

    [SerializeField]
    AudioSource pickupSound;

    bool once;

	// Use this for initialization
	protected void Start () {
        animator = GetComponentInParent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.root.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (PickupObject(other.GetComponentInParent<PlayerController>())) {
                if(!once) {
                    animator.SetTrigger("Pickup");
                    if (pickupSound) {
                        pickupSound.Play();
                    }
                    once = true;
                }
            }
        }
    }

    abstract protected bool PickupObject(PlayerController player);
    
    public void DestroyMe() {
        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
