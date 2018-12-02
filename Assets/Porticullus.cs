using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porticullus : MonoBehaviour {
    protected Animator animator;
    [SerializeField]
    bool triggered;

    // Use this for initialization
     void Start() {
        animator = GetComponentInParent<Animator>();
        if (triggered) {
            animator.SetTrigger("Trigger");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (triggered) {
            return;
        }

        if (other.transform.root.gameObject.layer == LayerMask.NameToLayer("Player")) {
            animator.SetTrigger("Trigger");    
        }
    }
}
