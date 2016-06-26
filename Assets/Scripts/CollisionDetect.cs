using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");
        Destroy(other.gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
