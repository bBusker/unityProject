using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;
    public GameObject foodPickup_tiny;
    public GameObject magnetPickup;
    public bool MagnetPowerup_enabled;
    private float PickupRange_x;
    private float PickupRange_y;
    private GameObject Background;
    private ResolutionController ResolutionController;
    private GameObject Player;
    private PlayerTail playerTail;

    void Start () {
        scoreCount = 0;
        SetCountText();
        Player = GameObject.Find("Player");
        playerTail = Player.GetComponent<PlayerTail>();
        Background = GameObject.Find("Background");
        ResolutionController = Background.GetComponent<ResolutionController>();
        PickupRange_x = 20F * ResolutionController.ResolutionControllerRatio_x;
        PickupRange_y = 10F * ResolutionController.ResolutionControllerRatio_y;
        MagnetPowerup_enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Vector2 location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
            while (playerTail.checkPkupLocation(playerTail.TailList, location) == true)
            {
                location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
                Debug.Log("new location trigger");
            }
            Instantiate(foodPickup, location, Quaternion.identity);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            scoreCount += 5;
            SetCountText();
        }
        if (other.gameObject.CompareTag("TinyPickup"))
        {
            Vector2 location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
            while (playerTail.checkPkupLocation(playerTail.TailList, location) == true)
            {
                location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
                Debug.Log("new location trigger");
            }
            Instantiate(foodPickup_tiny, location, Quaternion.identity);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            scoreCount += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Magnet"))
        {
            MagnetPowerup_enabled = true;
            Invoke("DeactivateMagnet", 10F);
            Invoke("SpawnMagnet", 15F);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    void DeactivateMagnet()
    {
        MagnetPowerup_enabled = false;
    }

    void SpawnMagnet()
    {
        Vector2 location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
        while (playerTail.checkPkupLocation(playerTail.TailList, location) == true)
        {
            location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
            Debug.Log("new location trigger");
        }
        Instantiate(magnetPickup, location, Quaternion.identity);
    }

    void SetCountText()
    {
        score.text = "SCORE: " + scoreCount.ToString();
    }

}
