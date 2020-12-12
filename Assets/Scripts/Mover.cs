using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Move obstacles automatically
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
