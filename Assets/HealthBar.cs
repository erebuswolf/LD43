using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    [SerializeField]
    SpriteRenderer healthSpriteRenderer;
    [SerializeField]
    SpriteRenderer darkHealthSpriteRenderer;

    [SerializeField]
    List<Sprite> HealthSprites;

    [SerializeField]
    List<Sprite> DarkHealthSprites;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHealth(int health, int darkHealth) {
        SetHealthVals(healthSpriteRenderer, health, HealthSprites);
        SetHealthVals(darkHealthSpriteRenderer, darkHealth, DarkHealthSprites);
    }

    private static void SetHealthVals(SpriteRenderer sr, int val, List<Sprite> sprites) {
        if (val == 0 || val > sprites.Count) {
            sr.sprite = null;
        } else {
            sr.sprite = sprites[val - 1];
        }

    }
}
