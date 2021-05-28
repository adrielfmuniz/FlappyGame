using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    Rigidbody2D rb;

    public float Force = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector2(0, Force));
        }
        
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler (0, 0, 45);
        } else if (rb.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler (0, 0, -45);
        } else 
        {
            transform.rotation = Quaternion.Euler (0, 0, 0);
        }
    }
}
