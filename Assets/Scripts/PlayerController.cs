using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0;
    public float maxSpeed = 0;
    public bool isSneaking;
    public float jumpForce = 5f;
    public float speedometer = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private bool isGrounded = true;
    private int count;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
        isSneaking = false;
        maxSpeed = 10;

    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){//die

            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive (true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    private void FixedUpdate()
    {
        //todo 
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift)) //sneak
        {
            isSneaking = !isSneaking;
        }

        if (isSneaking)
        {
            maxSpeed = 3;
        }
        else
        {
            maxSpeed = 10;

        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity= rb.linearVelocity.normalized *maxSpeed;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))//jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        speedometer = rb.linearVelocity.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText() ;
        }
       
    }

}
