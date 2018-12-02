using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : KillableActor {

    [SerializeField]
    RuntimeAnimatorController controller;


    [SerializeField]
    AudioSource powerupSound;

    // Use this for initialization
    new void Start () {
        base.Start();
    }

    bool once;
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate() {
        PushAway();
    }

    public void BloodMaxed() {
        TransformMonster();
    }

    void TransformMonster() {
        if (once) {
            return;
        }
        once = true;
        if (powerupSound) {
            powerupSound.Play();
        }
        var mymovement = GetComponent<Movement>();
        mymovement.SetVals(2.1f, 11);
        GetComponent<MonsterAI>().AggroRange = 6;
        GetComponent<MonsterAI>().Eps = .6f;

        var animator = GetComponent<Animator>();
        animator.SetTrigger("Transform");
        animator.runtimeAnimatorController = controller;

        var health = GetComponent<Health>();
        health.AddDarkHealth(6);
    }

    void PushAway () {
        var monsters = Physics2D.OverlapCircleAll(this.transform.position, .3f, LayerMask.GetMask("Monster"));
        foreach (var m in monsters) {
            if (m.gameObject != this.gameObject) {
                Vector2 diff = (m.gameObject.transform.position - this.transform.position );
                var thing = m.GetComponent<Rigidbody2D>();
                if (thing) {
                    thing.AddForce(diff.normalized * 5);
                }
            }
        }
    }
}
