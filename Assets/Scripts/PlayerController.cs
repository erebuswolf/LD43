using UnityEngine;

public class PlayerController : MonoBehaviour {
    Movement movement;
    
    
    // Use this for initialization
    void Start () {
        movement = this.GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void Update () {
        bool inputMoveRight = Input.GetKey(KeyCode.RightArrow);
        bool  inputMoveLeft = Input.GetKey(KeyCode.LeftArrow);
        bool Jump = Input.GetKeyDown(KeyCode.Space);
        bool attacking = Input.GetKeyDown(KeyCode.F);

        movement.SetValues(inputMoveRight, inputMoveLeft, Jump, attacking);
        
    }
    

}
