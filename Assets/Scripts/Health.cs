using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    int CurrentHealth;

    [SerializeField]
    int CurrentDarkHealth;

    HealthBar healthBar;
    
    public void ApplyDamage(int Damage, Vector3 position) {
        if (CurrentDarkHealth > 0) {
            CurrentDarkHealth -= Damage;
            if (CurrentDarkHealth < 0) {
                CurrentHealth += CurrentDarkHealth;
                CurrentDarkHealth = 0;
            }
        } else {
            CurrentHealth -= Damage;
            if (CurrentHealth <= 0) {
                TriggerDeath();
                CurrentHealth = 0;
            }
        }

        SendMessageUpwards("Damaged", position,SendMessageOptions.DontRequireReceiver);
        if (healthBar) {
            healthBar.SetHealth(CurrentHealth, CurrentDarkHealth);
        }
    }
    
    public void HealSetAmnt() {
        HealHealth(2);
    }

    public bool AddDarkHealth(int health) {
        if (CurrentDarkHealth == 6) {
            return false;
        }
        CurrentDarkHealth += health;
        if (CurrentDarkHealth > 6) {
            CurrentDarkHealth = 6;
        }
        
        if (healthBar) {
            healthBar.SetHealth(CurrentHealth, CurrentDarkHealth);
        }
        return true;
    }

    public void HealHealth(int Heal) {
        CurrentHealth += Heal;
        if (CurrentHealth > 6) {
            CurrentHealth = 6;
        }
        if (healthBar) {
            healthBar.SetHealth(CurrentHealth, CurrentDarkHealth);
        }
    }

    public void TriggerDeath() {
        SendMessageUpwards("Death", SendMessageOptions.DontRequireReceiver);
    }

	// Use this for initialization
	void Start () {
        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar) {
            healthBar.SetHealth(CurrentHealth, CurrentDarkHealth);
        }
        if (CurrentDarkHealth == 0 && CurrentHealth == 0) {
            TriggerDeath();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
