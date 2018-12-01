using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRun : AiControllerBase {
    [SerializeField]
    bool runRight;

    bool jump;
    
	// Use this for initialization
	new void Start () {
        base.Start();
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
        movement.SetValues(runRight, !runRight, jump, false);
        jump = false;
    }

    public void OnJumpPad() {
        jump = true;
    }
}
