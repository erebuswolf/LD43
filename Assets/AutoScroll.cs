using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour {
    
    [SerializeField]
    GameObject Track;

    [SerializeField]
    float scale;
    
    [SerializeField]
    float minx;
    
    [SerializeField]
    float maxx;

    float offset;

    // Use this for initialization
    void Start () {
		offset = this.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        float lerpval = Track.transform.position.x * scale;
        var pos = this.transform.position;
        pos.x = Mathf.Lerp(maxx, minx, lerpval) + offset;

        if (pos.x < minx) {
            pos.x += maxx - minx;
        } else if (pos.x > maxx) {
            pos.x -= maxx - minx;
        }
        this.transform.position = pos;
    }
}
