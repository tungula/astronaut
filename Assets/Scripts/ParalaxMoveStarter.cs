using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMoveStarter : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position.x - player.transform.position.x) < 20)
        {
            gameObject.GetComponent<ParalaxMove>().enabled = true;
        }
    }
}
