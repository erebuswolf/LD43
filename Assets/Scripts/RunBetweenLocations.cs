using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBetweenLocations : AiControllerBase {

    [SerializeField]
    float eps;

    [SerializeField]
    GameObject LeftPoint;

    [SerializeField]
    GameObject RightPoint;

    GameObject CurrentTarget;


    // Use this for initialization
    new void Start () {
        base.Start();
        CurrentTarget = LeftPoint;
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        if (!Activated) {
            return;
        }

        if (dead) {
            movement.SetValues(false, false, false, false);
            return;
        }

        if (reachedTarget()) {
            CurrentTarget = CurrentTarget == LeftPoint ? RightPoint : LeftPoint;
        }

        bool runLeft = CurrentTarget.transform.position.x - this.transform.position.x < 0;
        
        movement.SetValues(!runLeft, runLeft, false, false);
    }

    bool reachedTarget() {
        return Mathf.Abs(CurrentTarget.transform.position.x - this.transform.position.x) < eps;
    }
}
