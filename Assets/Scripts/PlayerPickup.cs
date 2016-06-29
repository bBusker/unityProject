using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;
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
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.gameObject.CompareTag("Pickup"))
        {
            Vector2 location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
            while (playerTail.checkPkupLocation(playerTail.TailList, location) == true)
            {
                location = new Vector2(Random.Range(-PickupRange_x, PickupRange_x), Random.Range(-PickupRange_y, PickupRange_y));
                Debug.Log("new location trigger");
            }
            Instantiate(foodPickup, location, Quaternion.identity);
            food.gameObject.SetActive(false);
            Destroy(food.gameObject);
            scoreCount += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        score.text = "SCORE: " + scoreCount.ToString();
    }

}
