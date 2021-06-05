using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Rigidbody2D rb; 
    AudioSource wingSound;
    AudioSource hitSound;
    AudioSource pointSound;
    Vector3 initialPosition;

    public float Force = 100f;
    public bool IsAlive = true;
    public bool IsGameStarted = false;
    public bool IsGrounded = false;
    public int Points = 0;
    public Text PointText;
    public Button BtnStart;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        wingSound = GetComponents<AudioSource>()[0];
        hitSound = GetComponents<AudioSource>()[1];
        pointSound = GetComponents<AudioSource>()[2];
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (IsGameStarted == true) {
            if (Input.GetMouseButtonDown(0) && IsAlive == true) {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2 (0, Force));
                wingSound.Play();
            }

            if (IsGrounded == false) {
                if (rb.velocity.y > 0) {
                    transform.rotation = Quaternion.Euler (0, 0, 45);
                } else if (rb.velocity.y < 0) {
                    transform.rotation = Quaternion.Euler (0, 0, -45);
                } else {
                    transform.rotation = Quaternion.Euler (0, 0, 0);
                }
            } else {
                transform.rotation = Quaternion.Euler (0, 0, -90);
            }
        } else {
            rb.velocity = Vector2.zero;
            transform.position = initialPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if ((coll.transform.CompareTag ("pipe") || coll.gameObject.name == "ground") && IsAlive == true) {
            IsAlive = false;
            hitSound.Play ();
            BtnStart.gameObject.SetActive (true);
            IsGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag ("pipe") && IsAlive == true) {
            Points = Points + 1;
            PointText.text = Points.ToString ();
            pointSound.Play ();
        }
    }

    public void OnGameStart () {
        foreach (var item in GameObject.FindGameObjectsWithTag ("pipe")) {
            GameObject.Destroy (item);
        }

        Points = 0;
        PointText.text = Points.ToString ();
        transform.position = initialPosition;
        IsAlive = true;
        rb.velocity = Vector2.zero;
        IsGameStarted = true;
        BtnStart.gameObject.SetActive (false);
        IsGrounded = false;
    }
}
