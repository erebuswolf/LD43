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

    [SerializeField]
    BoxCollider2D JumpCheck;

    [SerializeField]
    float JumpCD;

    [SerializeField]
    float TeleDist;


    [SerializeField]
    AudioSource JumpSound;

    private float LastJumpTime;
    
    bool Dead;

    Animator animator;
    Health health;

    Rigidbody2D myBody;

    BloodManager bloodmanager;

    bool inputMoveRight;
    bool inputMoveLeft;
    bool Jump;
    bool grounded;
    bool attacking;
    bool bloodAttack;
    bool heal;
    bool teleport;

    bool DoingSomething;

    Vector3 DamageForceToAdd = Vector3.zero;

    // Use this for initialization
    void Start() {
        myBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        bloodmanager = this.GetComponent<BloodManager>();
        health = this.GetComponent<Health>();
    }

    public void Death() {
        Dead = true;
    }
    
    public void Damaged(Vector3 position) {
        if(!Dead) {
            animator.SetTrigger("Flinch");
            DamageForceToAdd = (this.transform.position - position).normalized * 120;
        }
    }
    
    public void BigDamaged(Vector3 position) {
        if (!Dead) {
            animator.SetTrigger("Flinch");
            DamageForceToAdd = (this.transform.position - position).normalized * 200;
        }
    }

    public void StopAttack() {
        DoingSomething = false;
        attacking = false;
    }

    public void SetVals(float MAX_XVEL, float WALK_FORCE) {
        this.MAX_XVEL = MAX_XVEL;
        this.WALK_FORCE = WALK_FORCE;
    }

    public void StartAttack() {
        DoingSomething = true;
    }

    public void SetValues(bool inputMoveRight, bool inputMoveLeft, bool Jump, bool attacking = false, bool bloodAttack = false, bool heal = false, bool teleport = false) {
        this.inputMoveRight = inputMoveRight;
        this.inputMoveLeft = inputMoveLeft;
        this.Jump |= Jump;
        this.attacking |= attacking;
        this.bloodAttack |= bloodAttack;
        this.heal |= heal;
        this.teleport |= teleport;
        if (DoingSomething) {
            this.attacking = false;
            this.heal = false;
            this.bloodAttack = false;
            this.teleport = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Dead) {
            return;
        }
        // Logic to determine AI actions
        if (bloodAttack) {
            if (bloodmanager.TryToSpendBlood(60)) {
                DoingSomething = true;
                animator.SetTrigger("BloodAttack");
            } else {
                // Trigger not enough blood sound.
            }
            bloodAttack = false;
        } else if (attacking) {
            DoingSomething = true;
            animator.SetTrigger("Attack");
            attacking = false;
        } else if (heal) {
            if (health.getHealth() < 6 && bloodmanager.TryToSpendBlood(50)) {
                DoingSomething = true;
                animator.SetTrigger("Heal");
            } else {
                // Trigger not enough blood sound.
            }
            heal = false;
        } else if (teleport) {
            if (bloodmanager.TryToSpendBlood(10)) {
                DoingSomething = true;
                animator.SetTrigger("Teleport");
            } else {
                // Trigger not enough blood sound.
            }
            teleport = false;
        }
    }

    public void Teleport() {
        var cast = Physics2D.BoxCast(this.transform.position, new Vector2(.15f, .5f), 0, FacingRight? Vector2.right : Vector2.left, TeleDist, LayerMask.GetMask("Level"));
        if (!cast) {
            this.transform.position = this.transform.position + (FacingRight ? Vector3.right : Vector3.left) * TeleDist;
        } else {
            this.transform.position = cast.centroid;
        }
    }

    public bool isFacingRight() {
        return FacingRight;
    }

    public bool isGrounded() {
        return grounded;
    }

    private void FixedUpdate() {
        myBody.AddForce(DamageForceToAdd);
        DamageForceToAdd = Vector3.zero;

        if (Dead) {
            return;
        }
        grounded = GroundCheck.IsTouchingLayers(LayerMask.GetMask("Level"));

        if (DoingSomething) {
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
                JumpSound.Play();
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
