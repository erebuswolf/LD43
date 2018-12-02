﻿using UnityEngine;

public class PlayerController : KillableActor {
    Movement movement;
    
    // Use this for initialization
    new void Start () {
        base.Start();
        movement = this.GetComponent<Movement>();
    }
	
    public void Damaged() {

    }

	// Update is called once per frame
	void Update () {
        bool inputMoveRight = Input.GetKey(KeyCode.RightArrow);
        bool  inputMoveLeft = Input.GetKey(KeyCode.LeftArrow);
        bool Jump = Input.GetKeyDown(KeyCode.Space);
        bool attacking = Input.GetKeyDown(KeyCode.F);

        bool bloodAttack = Input.GetKeyDown(KeyCode.D);
        
        bool heal = Input.GetKeyDown(KeyCode.G);


        movement.SetValues(inputMoveRight, inputMoveLeft, Jump, attacking, bloodAttack, heal);
        
    }
}
