using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float angaccel;

    public int scoreCount;
    public Text score;
    public GameObject foodPickup;


    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scoreCount = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(speed*moveVertical, 0);
        float torque = -1 * angaccel * moveHorizontal;
        rb2d.AddRelativeForce(movement);
        rb2d.AddTorque(torque);
    }



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
