using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innocent : MonoBehaviour {

    [SerializeField] GameObject sprite;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death() {
        animator.SetTrigger("Death");
    }
    
    public void ChangeSpriteLocation() {
        sprite.transform.localPosition = new Vector3(0.452f, 0);
    }

    public void BloodPickedUp() {
        animator.SetTrigger("BloodPickedUp");
    }

}
