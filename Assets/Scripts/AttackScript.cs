using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    [SerializeField]
    int Damage;

    [SerializeField]
    GameObject Owner;

    LinkedList<GameObject> DamagedObjects = new LinkedList<GameObject>();

	// Use this for initialization
	void Start () {
    }

    private void OnEnable() {
        DamagedObjects.Clear();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == Owner && !DamagedObjects.Contains(other.transform.root.gameObject) ||
            other.transform.root.gameObject.layer == this.transform.root.gameObject.layer) {
            return;
        }
        //ApplyAttack
        Health health = other.GetComponentInParent<Health>();
        if (health) {
            health.ApplyDamage(Damage, this.transform.root.position);
            DamagedObjects.AddLast(other.transform.root.gameObject);
        }
    }
}
