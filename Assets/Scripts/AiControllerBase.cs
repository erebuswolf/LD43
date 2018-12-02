using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControllerBase : MonoBehaviour {
    protected Movement movement;

    [SerializeField]
    float ActivationDistance;

    protected bool Activated;

    private GameObject player;

    protected bool dead;

    // Use this for initialization
    protected void Start () {
        movement = GetComponent<Movement>();
        player = FindObjectOfType<PlayerController>().gameObject;
    }
	
	// Update is called once per frame
	protected void Update () {
		if(!Activated) {
            if(movement.isGrounded() && (ActivationDistance == 0 || (player.transform.position - transform.position).sqrMagnitude < ActivationDistance * ActivationDistance)) {
                Activated = true;
            }
        }
	}

    public void Death() {
        dead = true;
    }
}
