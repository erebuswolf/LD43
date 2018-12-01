using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableActor : MonoBehaviour {
    
    protected Animator animator;

    // Use this for initialization
    protected void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death() {
        animator.SetTrigger("Death");
    }
    
    public void BloodPickedUp() {
        animator.SetTrigger("BloodPickedUp");
    }
}
