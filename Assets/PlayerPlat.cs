using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlat : MonoBehaviour {
    PlayerController player;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if(player == collision.transform.root.gameObject) {
            SendMessageUpwards("PlayerOnPlat");
        }
    }
}
