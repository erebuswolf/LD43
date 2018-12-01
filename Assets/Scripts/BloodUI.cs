using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodUI : MonoBehaviour {
    [SerializeField]
    GameObject OneBloodSprite;

    [SerializeField]
    GameObject FullBloodSprite;

    const float bloodOffset = .02f;

    List<GameObject> BloodSprites = new List<GameObject>();

    // Use this for initialization
    void Start () {
        for(int i = 1; i < 100; i++) {
            var bs = Instantiate(OneBloodSprite, this.transform);
            bs.transform.localPosition = OneBloodSprite.transform.localPosition + Vector3.up * i * bloodOffset;
            bs.SetActive(false);
            BloodSprites.Add(bs);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HideAllSprites() {
        OneBloodSprite.SetActive(false);
        FullBloodSprite.SetActive(false);
        foreach(GameObject bs in BloodSprites) {
            bs.SetActive(false);
        }
    }

    public void SetBloodValue(int Value) {
        HideAllSprites();
        if (Value == 0) {
        } else if (Value == 100) {
            FullBloodSprite.SetActive(true);
        } else {
            OneBloodSprite.SetActive(true);
            for (int i = 0; i < Value-1; i++) {
                BloodSprites[i].SetActive(true);
            }
        }
    }
}
