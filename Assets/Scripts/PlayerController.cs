using UnityEngine;
using System.Collections;

public class PlayerController : KillableActor {
    Movement movement;

    [SerializeField]
    GameObject restarter;

    // Use this for initialization
    new void Start () {
        base.Start();
        movement = this.GetComponent<Movement>();
    }

    public override void Death() {
        base.Death();
        StartCoroutine(DelayRestart());
    }

    IEnumerator DelayRestart() {
        yield return new WaitForSeconds(2);
        restarter.gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () {
        bool inputMoveRight = Input.GetKey(KeyCode.RightArrow);
        bool  inputMoveLeft = Input.GetKey(KeyCode.LeftArrow);
        bool Jump = Input.GetKeyDown(KeyCode.Space);
        bool attacking = Input.GetKeyDown(KeyCode.F);

        bool bloodAttack = Input.GetKeyDown(KeyCode.D);
        
        bool heal = Input.GetKeyDown(KeyCode.A);
        bool teleport = Input.GetKeyDown(KeyCode.S);


        movement.SetValues(inputMoveRight, inputMoveLeft, Jump, attacking, bloodAttack, heal, teleport);
        
    }
}
