using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    float CurrentHealth;
    
    public void ApplyDamage(float Damage) {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0) {
            TriggerDeath();
        }
    }

    public void TriggerDeath() {
        SendMessageUpwards("Death");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
