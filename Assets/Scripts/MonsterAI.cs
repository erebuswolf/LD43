using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : AiControllerBase {
    [SerializeField]
    List<AudioSource> sounds;
    
    [SerializeField]
    public float AggroRange;
    
    [SerializeField]
    GameObject Target;

    [SerializeField]
    public float Eps;

    Animator animator;

    float randTime;
    bool randMoveRight;

	// Use this for initialization
	new void Start () {
        base.Start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update() {
        base.Update();

        if (!Activated) {
            return;
        }

        if (dead) {
            movement.SetValues(false, false, false, false);
            return;
        }
        FindTarget();
        if(Target) {
            MoveTowardTarget();
        } else {
            MoveRandom();
        }
    }

    void PlayPsycicSound() {
        sounds[0].Play();
    }

    void PlayattackSound() {
        sounds[1].Play();
    }

    void MoveRandom() {
        if (randTime < Time.time) {
            randMoveRight = Random.Range(0, 2) == 0;
            randTime = Time.time + Random.value * 2 + 1;
        }

        movement.SetValues(randMoveRight, !randMoveRight, false, false);
    }

    void MoveTowardTarget() {
        if (!Target) {
            return;
        }
        if (Eps > Mathf.Abs(Target.transform.position.x - this.transform.position.x)
            && movement.isFacingRight() == (Target.transform.position.x - this.transform.position.x) > 0 && 
            !Target.GetComponent<KillableActor>().isDead()) {
            movement.SetValues(false, false, false, true);
        } else {
            bool moveleft = (Target.transform.position.x - this.transform.position.x) < 0;
            movement.SetValues(!moveleft, moveleft, false, false);
        }
    }
    
    void FindTarget() {
        GameObject closest = null;
        float closestDist = Mathf.Infinity;
        var collision = Physics2D.OverlapCircleAll(this.transform.position, AggroRange, LayerMask.GetMask("NPC", "Player"));
        foreach (var go in collision) {
            var player = go.GetComponentInParent<PlayerController>();
            if (player && !player.isDead()) {
                Target = player.gameObject;
                return;
            }

            var killable = go.GetComponentInParent<KillableActor>();
            
            if (killable) {
                var pickup = killable.gameObject.GetComponentInChildren<BloodPickup>();
                if (!killable.isDead() || pickup && !pickup.PickedUp()) {
                    if (closest) {
                        float dist = (killable.transform.position - transform.position).sqrMagnitude;
                        if (closestDist > dist) {
                            closest = killable.gameObject;
                            closestDist = dist;
                        }
                    } else {
                        closest = killable.gameObject;
                    }
                }
            }
        }
        Target = closest;
    }
}
