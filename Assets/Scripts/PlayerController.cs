using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float angaccel;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
}
