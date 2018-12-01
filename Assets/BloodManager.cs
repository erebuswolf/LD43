﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour {

    [SerializeField]
    int bloodVialCount = 1;
    [SerializeField]
    int CurrentBloodAmount = 0;

    BloodUI bloodUI;

    public bool CollectBlood(int amount) {
        if(CurrentBloodAmount == bloodVialCount * 100) {
            return false;
        }

        CurrentBloodAmount += amount;
        if (CurrentBloodAmount > bloodVialCount * 100) {
            CurrentBloodAmount = bloodVialCount * 100;
        }

        int uiAmount = CurrentBloodAmount;
        if (uiAmount > 100) {
            uiAmount = CurrentBloodAmount % 100;
            if (uiAmount == 0) {
                uiAmount = 100;
            }
        }

        bloodUI.SetBloodValue(uiAmount);
        return true;
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
        bloodUI = FindObjectOfType<BloodUI>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
