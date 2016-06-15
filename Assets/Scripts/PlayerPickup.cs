using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;

    void Start () {
        scoreCount = 0;
        SetCountText();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.gameObject.CompareTag("Pickup"))
        {
            Instantiate(foodPickup, new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F)), Quaternion.identity);
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
