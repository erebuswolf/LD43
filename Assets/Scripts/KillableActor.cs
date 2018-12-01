using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableActor : MonoBehaviour {
    
    protected Animator animator;
    protected bool dead;

    // Use this for initialization
    protected void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Death() {
        if (animator) {
            animator.SetTrigger("Death");
        }
        dead = true;
    }
    
    public void BloodPickedUp() {
        animator.SetTrigger("BloodPickedUp");
    }

    public bool isDead() {
        return dead;
    }
}
