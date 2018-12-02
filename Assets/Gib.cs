using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gib : KillableActor {

    Rigidbody2D myBody;
    // Use this for initialization
    new void Start () {
        base.Start();

        myBody = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Damaged(Vector3 position) {
        myBody.AddForceAtPosition((this.transform.position - position).normalized * 120, position);
    }
}
