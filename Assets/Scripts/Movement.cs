using System.Collections;
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

    Animator animator;

    Rigidbody2D myBody;

    bool inputMoveRight;
    bool inputMoveLeft;
    bool Jump;
    bool grounded;
    bool attacking;

    // Use this for initialization
    void Start() {
        myBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    public void SetValues(bool inputMoveRight, bool inputMoveLeft, bool Jump, bool attacking) {
        this.inputMoveRight = inputMoveRight;
        this.inputMoveLeft = inputMoveLeft;
        this.Jump |= Jump;
        this.attacking |= attacking;
    }

    // Update is called once per frame
    void Update() {
        // Logic to determine AI actions

        if (attacking) {
            animator.SetTrigger("Attack");
            attacking = false;
        }
    }

    private void FixedUpdate() {

        grounded = GroundCheck.IsTouchingLayers(LayerMask.GetMask("Level"));

        if (inputMoveRight) {
            myBody.AddForce(new Vector2(WALK_FORCE, 0));
            FacingRight = true;
        } else if (inputMoveLeft) {
            myBody.AddForce(new Vector2(-WALK_FORCE, 0));
            FacingRight = false;
        }
        if (Jump) {
            if (grounded) {
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
