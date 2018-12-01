using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour {

    [SerializeField]
    int bloodVialCount = 1;
    [SerializeField]
    int CurrentBloodAmount = 0;

    public void CollectBlood(int amount) {
        CurrentBloodAmount += amount;
        if (CurrentBloodAmount > bloodVialCount * 100) {
            CurrentBloodAmount = bloodVialCount * 100;
        }
    }

    public bool TryToSpendBlood(int amount) {
        if (CurrentBloodAmount >= amount) {
            CurrentBloodAmount -= amount;
            return true;
        }
        return false;
    }

    public void CollectVial() {
        bloodVialCount++;
    }

    public int GetVialCount() {
        return bloodVialCount;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
