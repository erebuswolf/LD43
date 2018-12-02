using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    Animator animator;

    bool PlayerOnPlatform = false;

    float BlinkTime = 0;

    [SerializeField]
    GameObject enemyBasic;

    [SerializeField]
    GameObject BloodPickup;

    [SerializeField]
    GameObject EnemyAdvanced;
    
    [SerializeField]
    List<GameObject> EnemySpawns;
    
    [SerializeField]
    List<GameObject> PickupSpawns;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        var info = animator.GetCurrentAnimatorStateInfo(0);

        // Decide Between Platform raising, enemy summoning, and attacking.
        if(info.IsName("bossIdle")) {
            Debug.LogWarning("boss is idle");
        }
        
        var platforminfo = animator.GetCurrentAnimatorStateInfo(2);
        if (info.IsName("EyeIdle")) {
            RandomBlink();
        }
    }
    

    public void SpawnWave1() {

    }

    public void SpawnWave2() {

    }

    public void SpawnWave3() {

    }

    public void RandomBlink() {
        if (Time.time > BlinkTime) {
            animator.SetTrigger("Blink");
            BlinkTime = Time.time + 4 + Random.value * 10;
        }
    }

    public void BigDamaged() {

    }
    
    public void Damaged() {

    }

    public void PlayerOnPlat() {
        PlayerOnPlatform = true;
    }
}
