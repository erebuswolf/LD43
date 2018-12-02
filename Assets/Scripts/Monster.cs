using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : KillableActor {
    
	// Use this for initialization
	new void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate() {
        PushAway();
    }

    void PushAway () {
        var monsters = Physics2D.OverlapCircleAll(this.transform.position, .3f, LayerMask.GetMask("Monster"));
        foreach (var m in monsters) {
            if (m.gameObject != this.gameObject) {
                Vector2 diff = (m.gameObject.transform.position - this.transform.position );
                m.GetComponent<Rigidbody2D>().AddForce(diff.normalized * 5);
            }
        }
    }
}
