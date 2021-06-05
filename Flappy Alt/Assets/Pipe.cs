using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float Speed = 1f;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive == true) 
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - Speed * Time.deltaTime;
            transform.position = pos;

            if (transform.position.x < -5f) {
                GameObject.Destroy (gameObject);
            }
        }
    }
}
