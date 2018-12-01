using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    const float MAX_VEL = 50;

    const float MAX_XVEL = 2;

    const float WALK_FORCE = 10;

    const float JUMP_FORCE = 200;



    [SerializeField]
    BoxCollider2D GroundCheck;

    Rigidbody2D myBody;

    bool inputMoveRight;
    bool inputMoveLeft;
    bool Jump;
    bool grounded;


    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        inputMoveRight = Input.GetKey(KeyCode.RightArrow);
        inputMoveLeft = Input.GetKey(KeyCode.LeftArrow);

        grounded = GroundCheck.IsTouchingLayers(LayerMask.GetMask("Level"));

        Jump = Input.GetKeyDown(KeyCode.Space);

        if (inputMoveRight) {
            myBody.AddForce(new Vector2(WALK_FORCE, 0));
        } else if (inputMoveLeft) {
            myBody.AddForce(new Vector2(-WALK_FORCE, 0));
        }
        if (Jump && grounded) {
            myBody.AddForce(new Vector2(0, JUMP_FORCE));
        }

        if (myBody.velocity.magnitude > MAX_VEL) {
            myBody.velocity = myBody.velocity.normalized * MAX_VEL;
        }

        if (Mathf.Abs( myBody.velocity.x) > MAX_XVEL) {
            myBody.velocity = new Vector2(Mathf.Sign(myBody.velocity.x) * MAX_XVEL, myBody.velocity.y);
        }
    
    }
    
}
