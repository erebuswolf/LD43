using UnityEngine;

public class PlayerController : KillableActor {
    Movement movement;
    
    // Use this for initialization
    void Start () {
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
        
        movement.SetValues(inputMoveRight, inputMoveLeft, Jump, attacking, bloodAttack);
        
    }
    
    public void Death() {
        dead = true;
        Debug.LogWarning("you died!");
    }


}
