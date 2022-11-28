using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float maxSpeed = 0;
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public GameObject Level1End;
    public GameObject VictoryPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Level1End.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity=rb.velocity.normalized*maxSpeed*Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Level1End.SetActive(true);
            VictoryPoint.SetActive(false);
        }
    }

}
