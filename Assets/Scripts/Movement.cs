﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    float MAX_VEL = 50;

    [SerializeField]
    float MAX_XVEL = 2;

    [SerializeField]
    float WALK_FORCE = 10;

    [SerializeField]
    float JUMP_FORCE = 200;

    bool FacingRight = true;

    [SerializeField]
    BoxCollider2D GroundCheck;

    [SerializeField]
    BoxCollider2D JumpCheck;

    [SerializeField]
    float JumpCD;

    private float LastJumpTime;
    
    bool Dead;

    Animator animator;

    Rigidbody2D myBody;

    BloodManager bloodmanager;

    bool inputMoveRight;
    bool inputMoveLeft;
    bool Jump;
    bool grounded;
    bool attacking;
    bool bloodAttack;

    bool AttackAnimation;

    // Use this for initialization
    void Start() {
        myBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        bloodmanager = this.GetComponent<BloodManager>();
    }

    public void Death() {
        Dead = true;
    }
    
    public void Damaged(Vector3 position) {
        if(!Dead) {
            myBody.AddForce((this.transform.position - position).normalized * 100);
        }
    }

    public void StopAttack() {
        AttackAnimation = false;
        attacking = false;
    }
    
    public void StartAttack() {
        AttackAnimation = true;
    }

    public void SetValues(bool inputMoveRight, bool inputMoveLeft, bool Jump, bool attacking = false, bool bloodAttack = false) {
        this.inputMoveRight = inputMoveRight;
        this.inputMoveLeft = inputMoveLeft;
        this.Jump |= Jump;
        this.attacking |= attacking;
        if (AttackAnimation) {
            this.attacking = false;
        }
        this.bloodAttack |= bloodAttack;
    }

    // Update is called once per frame
    void Update() {

        if (Dead) {
            return;
        }
        // Logic to determine AI actions
        if (bloodAttack) {
            if (bloodmanager.TryToSpendBlood(30)) {
                AttackAnimation = true;
                animator.SetTrigger("BloodAttack");
            } else {
                // Trigger not enough blood sound.
            }
            bloodAttack = false;
        } else if (attacking) {
            AttackAnimation = true;
            animator.SetTrigger("Attack");
            attacking = false;
        }
    }

    public bool isFacingRight() {
        return FacingRight;
    }

    private void FixedUpdate() {
        if (Dead) {
            return;
        }
        grounded = GroundCheck.IsTouchingLayers(LayerMask.GetMask("Level"));

        if (AttackAnimation) {
            return;
        }

        bool shouldJump = false;
        if (JumpCheck) {
            shouldJump  = JumpCheck.IsTouchingLayers(LayerMask.GetMask("Level"));
        }
        
        if (inputMoveRight) {
            myBody.AddForce(new Vector2(WALK_FORCE, 0));
            FacingRight = true;
        } else if (inputMoveLeft) {
            myBody.AddForce(new Vector2(-WALK_FORCE, 0));
            FacingRight = false;
        }
        if (Jump || shouldJump && LastJumpTime + JumpCD < Time.time) {
            if (grounded) {
                LastJumpTime = Time.time;
                myBody.AddForce(new Vector2(0, JUMP_FORCE));
            }
            Jump = false;
        }

        if (myBody.velocity.magnitude > MAX_VEL) {
            myBody.velocity = myBody.velocity.normalized * MAX_VEL;
        }

        if (Mathf.Abs(myBody.velocity.x) > MAX_XVEL) {
            myBody.velocity = new Vector2(Mathf.Sign(myBody.velocity.x) * MAX_XVEL, myBody.velocity.y);
        }
        if (!FacingRight) {
            this.transform.localScale = new Vector3(-1, 1, 1);
        } else {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
