using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    Animator animator;

    bool PlayerOnPlatform = false;

    [SerializeField]
    float BlinkTime = 0;

    [SerializeField]
    GameObject enemyBasic;

    [SerializeField]
    GameObject BloodPickup;
    
    [SerializeField]
    GameObject Innocent;

    [SerializeField]
    GameObject HeartPickup;

    [SerializeField]
    GameObject EnemyAdvanced;
    
    [SerializeField]
    List<GameObject> Spawns;

    // State 0, wait for player to get on platform.
    // player gets on platform, platform rises
    // player attacks boss, boss reacts. pull arm away.

    // state 1, summons wave 1
    // state 2, attacks
    // state 3, wait for player to get on platform and repeat.

    // wave 2 and 3.

    int bossState = 0;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        var baseinfo = animator.GetCurrentAnimatorStateInfo(0);
        var eyeinfo = animator.GetCurrentAnimatorStateInfo(1);
        var platforminfo = animator.GetCurrentAnimatorStateInfo(2);
        switch (bossState) {
            case 0:
                if (platforminfo.IsName("EyeIdle") && PlayerOnPlatform) {
                    animator.SetTrigger("PlatformUp");
                } else if (!PlayerOnPlatform) {
                    if(platforminfo.IsName("PlatformLift")) {
                        animator.SetTrigger("PlatformOut");
                    } else if (platforminfo.IsName("PlatformLower")) {
                        animator.SetTrigger("PlatformReset");
                    }
                }
                break;
            default:
                break;
        }
        // Decide Between Platform raising, enemy summoning, and attacking.
        if(baseinfo.IsName("bossIdle")) {

            if (bossState == 0) {
                
            }
        }
        

        if (platforminfo.IsName("EyeIdle")) {
            RandomBlink();
        } 
    }
    
    IEnumerable SpawnWave1() {
        // 5 Blood 2 basic Enemies;
        Instantiate(BloodPickup, Spawns[6].transform);
        Instantiate(BloodPickup, Spawns[5].transform);
        Instantiate(Innocent, Spawns[4].transform);
        Instantiate(BloodPickup, Spawns[2].transform);
        Instantiate(Innocent, Spawns[1].transform);
        yield return new WaitForSeconds(2);
        Instantiate(enemyBasic, Spawns[0].transform);
        Instantiate(enemyBasic, Spawns[3].transform);
    }

    IEnumerable SpawnWave2() {
        // 3 Blood 2 heart 2 Enemies (1 basic one advanced);
        Instantiate(HeartPickup, Spawns[6].transform);
        Instantiate(EnemyAdvanced, Spawns[5].transform);
        Instantiate(Innocent, Spawns[4].transform);
        Instantiate(Innocent, Spawns[2].transform);
        Instantiate(HeartPickup, Spawns[1].transform);
        yield return new WaitForSeconds(2);
        Instantiate(enemyBasic, Spawns[0].transform);
        Instantiate(BloodPickup, Spawns[3].transform);
    }

    IEnumerable SpawnWave3() {
        // 2 heart 3 Blood 2 Enemies (2 advanced);
        Instantiate(HeartPickup, Spawns[6].transform);
        Instantiate(Innocent, Spawns[5].transform);
        Instantiate(Innocent, Spawns[4].transform);
        Instantiate(EnemyAdvanced, Spawns[2].transform);
        Instantiate(HeartPickup, Spawns[1].transform);
        yield return new WaitForSeconds(2);
        Instantiate(BloodPickup, Spawns[0].transform);
        Instantiate(EnemyAdvanced, Spawns[3].transform);
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

    public void Death() {

    }

    public void PlayerOnPlat() {
        Debug.LogWarning("on plat");
        PlayerOnPlatform = true;
    }
    public void PlayerOffPlat() {
        PlayerOnPlatform = false;
        Debug.LogWarning("off plat");
    }
}
