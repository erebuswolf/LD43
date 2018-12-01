using UnityEngine;
using System.Collections;

public class MyFollowScript : MonoBehaviour {
    
    public float minDistanceX;
    public float minDistanceY;

    public GameObject target;
    public Vector3 offset;

    private Vector3 targetPos;

    // Use this for initialization
    void Start() {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (target) {

            Vector3 posNoZ = transform.position + offset;
   //         Vector3 targetDirection = (target.transform.position - posNoZ);
            

            Vector3 goal = target.transform.position + offset;
            goal.y = targetPos.y;

            /*
            if (Mathf.Abs(transform.position.x - goal.x) < minDistanceX) {
                return;
            }
            */

            transform.position = goal;

        }
    }
}
