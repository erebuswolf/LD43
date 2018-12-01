using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour {

    [SerializeField]
    int bloodVialCount = 1;
    [SerializeField]
    int CurrentBloodAmount = 0;

    [SerializeField]
    bool OnAI;

    BloodUI bloodUI;

    public bool CollectBlood(int amount) {
        if(CurrentBloodAmount == bloodVialCount * 100) {
            return false;
        }

        CurrentBloodAmount += amount;
        if (CurrentBloodAmount > bloodVialCount * 100) {
            CurrentBloodAmount = bloodVialCount * 100;
        }
        UpdateUI();
        return true;
    }
    private void UpdateUI() {
        if (OnAI) {
            return;
        }
        int uiAmount = CurrentBloodAmount;
        if (uiAmount > 100) {
            uiAmount = CurrentBloodAmount % 100;
            if (uiAmount == 0) {
                uiAmount = 100;
            }
        }
        if (!OnAI) {
            bloodUI.SetBloodValue(uiAmount);
        }
    }

    public bool TryToSpendBlood(int amount) {
        if (CurrentBloodAmount >= amount) {
            CurrentBloodAmount -= amount;
            UpdateUI();
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
        if (!OnAI) {
            bloodUI = FindObjectOfType<BloodUI>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
