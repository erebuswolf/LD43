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

    bool Dead;

    // State 0, wait for player to get on platform.
    // player gets on platform, platform rises
    // player attacks boss, boss reacts. pull arm away.
    
    // state 1,4,7  summons wave 1 
    // state 2, attacks
    // state 3, wait for player to get on platform and repeat.

    // wave 2 and 3.

    int bossState = 0;

    int waveSummoned = 0;

    public void AdvanceBossState() {
        bossState++;
        bossState %= 3;
        startedWave = false;
    }

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    bool startedWave = false;
	// Update is called once per frame
	void Update () {
        if (Dead) {
            return;
        }


        switch (bossState) {
            case 0:
                enticePlayer();
                break;
            case 1:
                if (!startedWave) {
                    startedWave = true;
                    switch(waveSummoned) {
                        case 0:
                            StartCoroutine(SpawnWave1());
                            break;
                        case 1:
                            StartCoroutine(SpawnWave2());
                            break;
                        default:
                            StartCoroutine(SpawnWave3());
                            break;
                    }
                    waveSummoned++;
                }
                break;
            case 2:
                if(!startedWave) {
                    Attack();
                }
                break;
            default:
                break;
        }

        var baseinfo = animator.GetCurrentAnimatorStateInfo(0);
        var platforminfo = animator.GetCurrentAnimatorStateInfo(2);
        // Decide Between Platform raising, enemy summoning, and attacking.
        if (baseinfo.IsName("bossIdle")) {

            if (bossState == 0) {
                
            }
        }
        
        if (platforminfo.IsName("EyeIdle")) {
            RandomBlink();
        } 
    }

    void Attack() {
        startedWave = true;
        animator.SetTrigger("Attack");
        animator.SetBool("ProtectEye", false);
    }

    void enticePlayer() {
        var baseinfo = animator.GetCurrentAnimatorStateInfo(0);
        var eyeinfo = animator.GetCurrentAnimatorStateInfo(1);
        var platforminfo = animator.GetCurrentAnimatorStateInfo(2);
        if (platforminfo.IsName("EyeIdle") && PlayerOnPlatform) {
            animator.SetTrigger("PlatformUp");
        } else if (!PlayerOnPlatform) {
            if (platforminfo.IsName("PlatformLift")) {
                animator.SetTrigger("PlatformOut");
            } else if (platforminfo.IsName("PlatformLower")) {
                animator.SetTrigger("PlatformReset");
            }
        }
    }

    IEnumerator SpawnWave1() {
        // 5 Blood 2 basic Enemies;
        yield return new WaitForSeconds(2);
        GameObject obj = Instantiate(BloodPickup);
        obj.transform.position = Spawns[6].transform.position;
        obj = Instantiate(BloodPickup);
        obj.transform.position = Spawns[5].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[4].transform.position;
        obj = Instantiate(BloodPickup);
        obj.transform.position = Spawns[2].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[1].transform.position;
        yield return new WaitForSeconds(2);
        obj = Instantiate(enemyBasic);
        obj.transform.position = Spawns[0].transform.position;
        obj = Instantiate(enemyBasic);
        obj.transform.position = Spawns[3].transform.position;
        yield return new WaitForSeconds(2);
        AdvanceBossState();
    }

    IEnumerator SpawnWave2() {
        yield return new WaitForSeconds(2);
        // 3 Blood 2 heart 2 Enemies (1 basic one advanced);
        GameObject obj = Instantiate(HeartPickup);
        obj.transform.position = Spawns[6].transform.position;

        obj = Instantiate(EnemyAdvanced);
        obj.transform.position = Spawns[5].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[4].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[2].transform.position;
        obj = Instantiate(HeartPickup);
        obj.transform.position = Spawns[1].transform.position;
        yield return new WaitForSeconds(2);
        obj = Instantiate(enemyBasic);
        obj.transform.position = Spawns[0].transform.position;
        obj = Instantiate(BloodPickup);
        obj.transform.position = Spawns[3].transform.position;
        yield return new WaitForSeconds(2);
        AdvanceBossState();
    }

    IEnumerator SpawnWave3() {
        yield return new WaitForSeconds(2);
        // 2 heart 3 Blood 2 Enemies (2 advanced);
        GameObject obj = Instantiate(HeartPickup);
        obj.transform.position = Spawns[6].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[5].transform.position;
        obj = Instantiate(Innocent);
        obj.transform.position = Spawns[4].transform.position;
        obj = Instantiate(EnemyAdvanced);
        obj.transform.position = Spawns[2].transform.position;
        obj = Instantiate(HeartPickup);
        obj.transform.position = Spawns[1].transform.position;
        yield return new WaitForSeconds(2);
        obj = Instantiate(BloodPickup);
        obj.transform.position = Spawns[0].transform.position;
        obj = Instantiate(EnemyAdvanced);
        obj.transform.position = Spawns[3].transform.position;
        yield return new WaitForSeconds(2);
        AdvanceBossState();
    }

    public void RandomBlink() {
        if (Time.time > BlinkTime) {
            animator.SetTrigger("Blink");
            BlinkTime = Time.time + 4 + Random.value * 10;
        }
    }
    
    bool reactingToDamage = false;
    public void BigDamaged() {
        animator.SetTrigger("Flinch");
        if (!reactingToDamage) {
            reactingToDamage = true;
            StartCoroutine(DamagedReact());
        }
    }
    
    public void Damaged() {
        animator.SetTrigger("Flinch");
        if (!reactingToDamage) {
            reactingToDamage = true;
            StartCoroutine(DamagedReact());
        }
    }

    IEnumerator DamagedReact() {
        yield return new WaitForSeconds(1);
        AdvanceBossState();
        animator.SetTrigger("PlatformOut");

        animator.SetBool("ProtectEye", true);

        yield return new WaitForSeconds(1);
        reactingToDamage = false;
    }

    public void Death() {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetTrigger("Death");
        Dead = true;
        StopAllCoroutines();
    }

    public void PlayerOnPlat() {
        PlayerOnPlatform = true;
    }
    public void PlayerOffPlat() {
        PlayerOnPlatform = false;
    }
}
