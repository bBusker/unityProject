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

    /*void FixedUpdate()
    {
        float horizAxis = Input.GetAxis("Horizontal");
        float torque = -1 * angaccel * horizAxis;               //Moving forward with AddRelativeForce
        rb2d.AddTorque(torque);
        rb2d.AddRelativeForce(new Vector2(speed, 0));
    }*/

    void FixedUpdate()
    {
        float horizAxis = Input.GetAxis("Horizontal");
        float torque = -1 * angaccel * horizAxis;
        rb2d.AddTorque(torque);
        rb2d.MovePosition(rb2d.position + (speed * (Vector2)rb2d.transform.right) * Time.fixedDeltaTime);
    }
}
