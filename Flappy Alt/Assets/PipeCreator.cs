using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreator : MonoBehaviour
{
    Player player;
    float clock = 5f;

    public GameObject PipeBase;
    public float TimeToCreate = 3f;
    public float Range = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find ("player").GetComponent<Player> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive == true && player.IsGameStarted == true) {
            clock += Time.deltaTime;
            if (clock >= TimeToCreate) {
                clock = 0;

                Vector3 pos = transform.position;
                pos.y = pos.y - Random.Range (-Range, Range);
                GameObject.Instantiate (PipeBase, pos, Quaternion.identity);
            }
        }
    }
}
