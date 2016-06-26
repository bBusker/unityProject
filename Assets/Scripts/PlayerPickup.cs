using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;
    private GameObject Player;
    private PlayerTail playerTail;

    void Start () {
        scoreCount = 0;
        SetCountText();
        Player = GameObject.Find("Player");
        playerTail = Player.GetComponent<PlayerTail>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.gameObject.CompareTag("Pickup"))
        {
            Vector2 location = new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
            while (playerTail.checkPkupLocation(playerTail.TailList, location) == true)
            {
                location = new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
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
