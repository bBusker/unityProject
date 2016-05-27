using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float angaccel;

    public int foodCount;
    public int scoreCount;
    public Text score;
    public GameObject clone;
    public Collider2D food;


    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scoreCount = 0;
        foodCount = 0;
        SetCountText();
        while (foodCount == 0)
        {
            food.gameObject.SetActive(true);
            foodCount += 1;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(speed*moveVertical, 0);
        float torque = angaccel * moveHorizontal;
        rb2d.AddRelativeForce(movement);
        rb2d.AddTorque(torque);
    }



    void OnTriggerEnter2D(Collider2D food)
    {
        if (food.gameObject.CompareTag("Pickup"))
        {
            Instantiate(food, new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F)), Quaternion.identity);
            food.gameObject.SetActive(false);
            Destroy(food.gameObject);
            scoreCount += 1;
            foodCount -= 1;
            SetCountText();

            /**
             * Tails need fixing. The more tails there are, the harder it is to control the snake (ie. Snake gets pushed by the tail)
             */
            //Instantiate(clone);
        }
    }

    void SetCountText()
    {
        score.text = "SCORE: " + scoreCount.ToString();
    }

}
