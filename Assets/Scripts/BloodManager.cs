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

    bool dead;

    BloodUI bloodUI;

    public void Death() {
        dead = true;
    }

    public bool CollectBlood(int amount) {
        if(CurrentBloodAmount == bloodVialCount * 100 || dead) {
            return false;
        }

        CurrentBloodAmount += amount;
        if (CurrentBloodAmount > bloodVialCount * 100) {
            CurrentBloodAmount = bloodVialCount * 100;
        }

        CheckBloodMaxed();
        UpdateUI();
        return true;
    }

    private void CheckBloodMaxed() {
        if (CurrentBloodAmount == bloodVialCount * 100) {
            SendMessageUpwards("BloodMaxed", SendMessageOptions.DontRequireReceiver);
        }
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
            int fullVialCount;
            if(CurrentBloodAmount % 100 == 0 && CurrentBloodAmount > 0) {
                fullVialCount = (CurrentBloodAmount / 100) - 1;
            } else {
                fullVialCount = (CurrentBloodAmount / 100);
            }
            bloodUI.SetMiniVialCount(bloodVialCount - 1, fullVialCount);
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

    public bool CollectVial() {
        if (bloodVialCount >4) {
            return false;
        }
        bloodVialCount++;
        UpdateUI();
        return true;
    }

    public int GetVialCount() {
        return bloodVialCount;
    }

	// Use this for initialization
	void Start () {
        if (!OnAI) {
            bloodUI = FindObjectOfType<BloodUI>();
            UpdateUI();
        } else {
            CheckBloodMaxed();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
