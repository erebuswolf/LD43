using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : KillableActor {
    [SerializeField]
    GameObject hiddenObject;
    
    [SerializeField]
    List<GameObject> Gibs;

    [SerializeField]
    SpriteRenderer thisSprite;

    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Start();
	}

    public override void Death() {
        if(dead) {
            return;
        }
        base.Death();

        if (hiddenObject) {
            var gameObject = Instantiate(hiddenObject);
            gameObject.transform.position = this.transform.position;
        }
        thisSprite.enabled = false;
        SpawnGibs();
    }

    void SpawnGibs() {
        foreach(GameObject go in Gibs) {
            go.SetActive(true);
        }
    }
}
