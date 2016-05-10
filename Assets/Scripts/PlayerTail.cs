using UnityEngine;
using System.Collections;
using System;

public class PlayerTail : MonoBehaviour {

    public GameObject player;
    public GameObject playertail2;
    private Vector3 prevPos;
    private Vector3 prevprevPos;

     // Use this for initialization
	void Start () {
        prevPos = player.transform.position;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.position - transform.position).magnitude > 3.0F)
        {
            prevprevPos = transform.position;
            transform.position = prevPos;
            playertail2.transform.position = prevprevPos;
            prevPos = player.transform.position;
        }
    }
}
