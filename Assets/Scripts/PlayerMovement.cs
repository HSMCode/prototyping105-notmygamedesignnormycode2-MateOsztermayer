using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    public float halfPlayerWidth;
    Vector2 screenSize;

    private float boostTimer;   //timer for the speedboost 
    private bool boosting;      //to ensure whether the player is currently boosting or not

    // Start is called before the first frame update
    void Start()
    {
        // Set screen boundaries
        halfPlayerWidth = transform.localScale.x / -2;
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth, Camera.main.orthographicSize);

        rb = GetComponent<Rigidbody>();

        //set normal speed of the ship/player
        speed = 10f;
        boostTimer = 0;
        boosting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the ship/player:
        float hAxis = Input.GetAxis("Horizontal");

        
        Vector3 movement = new Vector3(hAxis, 0, 0) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        rb.AddForce(movement);

        //Map Boundaries
        if(transform.position.x < -screenSize.x)
        {
            //(OutOfBoundary)OOB_value : berechnet wie weit der Player ausserhalb Boundary rausgeflogen ist
            float OOB_value = Mathf.Abs(transform.position.x + screenSize.x);

            //Player kommt so weit von rechts, wie er nach links rausgeflogen ist
            transform.position = new Vector2(screenSize.x - OOB_value, transform.position.y);
            //transform.position = new Vector2(-screenSize.x, transform.position.y);
        }
        else if(transform.position.x > screenSize.x)
        {
            //(OutOfBoundary)OOB_value : berechnet wie weit der Player ausserhalb Boundary rausgeflogen ist
            float OOB_value = Mathf.Abs(screenSize.x - transform.position.x);

            //Player kommt so weit von links, wie er nach rechts rausgeflogen ist
            transform.position = new Vector2(-screenSize.x + OOB_value, transform.position.y);
            //transform.position = new Vector2(screenSize.x, transform.position.y);
        }

    }

    //if ship/player collides with speedObject, change speed and set boosting to true
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpeedBoost")
        {
            boosting = true;
            speed = 20f;
        }
    }
}
