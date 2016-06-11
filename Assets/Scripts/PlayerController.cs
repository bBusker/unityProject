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
        rb2d.isKinematic = false;
    }

    /*void FixedUpdate()
    {
        float horizAxis = Input.GetAxis("Horizontal");
        float torque = -1 * angaccel * horizAxis;               //Moving forward with AddRelativeForce
        rb2d.AddTorque(torque);
        rb2d.AddRelativeForce(new Vector2(speed, 0));
    }*/

    /*void FixedUpdate()
    {
        float horizAxis = Input.GetAxis("Horizontal");
        float torque = -1 * angaccel * horizAxis;               //Moving forward with MovePosition
        rb2d.AddTorque(torque);
        rb2d.MovePosition(rb2d.position + (speed * (Vector2)rb2d.transform.right) * Time.fixedDeltaTime);
    }*/

    /*void Update()
    {
        float horizAxis = Input.GetAxis("Horizontal");          //Moving and rotation, with the snake as a kinematic object
        rb2d.transform.Rotate(0, 0, -1 * angaccel * horizAxis * Time.deltaTime);
        rb2d.transform.position = transform.position + transform.right * Time.deltaTime * speed;
    }*/

    void FixedUpdate()
    {
        float xAxis = Input.acceleration.x;          //Mobile device accelerometer movement
        float yAxis = Input.acceleration.y;
        Vector2 movement = new Vector2(xAxis, yAxis);
        float movementRotation = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg;
        rb2d.transform.rotation = Quaternion.AngleAxis(movementRotation, Vector3.forward);
        rb2d.AddForce(movement * speed);
        rb2d.AddRelativeForce(new Vector2(speed/3, 0));
    }
}
