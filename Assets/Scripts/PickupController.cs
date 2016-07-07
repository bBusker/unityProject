using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    private GameObject Player;
    private PlayerPickup PlayerPickup;

	void Start () {
        Player = GameObject.Find("Player");
        PlayerPickup = Player.GetComponent<PlayerPickup>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(Vector3.Magnitude(Player.transform.position - transform.position) < 5F && PlayerPickup.MagnetPowerup_enabled == true)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, 0.07F);
        }
	}
}
