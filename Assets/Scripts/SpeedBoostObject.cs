using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostObject : MonoBehaviour
{
    public int speed;   //speed of the object

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(7,15);
    }

    // Update is called once per frame
    void Update()
    {
        //move object down the screen
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        //check to see if it has reached the bottom of the screen
        if(transform.position.y < -20)
        {
            //move object back to the top of the screen, give new random x coordinate and new random speed
            MoveToTop();
        }
    }

    void MoveToTop()
    {
        //generate random x coordinate
        float randomNumber = Random.Range(-3.65f, 3.65f);
        //make new Vector3 to store the new position for object to move to
        Vector3 newPos = new Vector3(randomNumber, 20, 0);
        //move object to new position
        transform.position = newPos;
        //give object new random speed
        speed = Random.Range(5, 15);
    }

    void OnTriggerEnter(Collider other)
    {
        //check to see if the other object was not a falling object 
        if(!other.CompareTag("Boundary"))
        {
            if(!other.CompareTag("Hazard"))
            {
                //move object back to the top of the screen, give new random x coordinate and new random speed
                MoveToTop();
            }
        }
    }

}
