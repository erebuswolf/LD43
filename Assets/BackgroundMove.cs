using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    [SerializeField]
    float startx;

    [SerializeField]
    float Endx;
    
    [SerializeField]
    GameObject Track;
    
    [SerializeField]
    float startTrackx;

    [SerializeField]
    float EndTrackx;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float lerpAmount = 0;

        float x = Track.transform.position.x;
        lerpAmount = (x - startTrackx) / (EndTrackx - startTrackx);
        lerpAmount = Mathf.Clamp01(lerpAmount);

        var pos = this.transform.position;

        pos.x = Mathf.Lerp(startx, Endx, lerpAmount);
        this.transform.position = pos;

    }
}
