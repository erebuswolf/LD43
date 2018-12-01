using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    [SerializeField]
    float Damage;

    [SerializeField]
    GameObject Owner;

	// Use this for initialization
	void Start () {
    }

    private void OnEnable() {

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == Owner) {
            return;
        }

        //ApplyAttack
        Health health = other.GetComponentInParent<Health>();
        if (health) {
            health.ApplyDamage(Damage);
        }
    }
}
