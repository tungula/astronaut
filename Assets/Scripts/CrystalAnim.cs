using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnim : MonoBehaviour
{
    private GameObject ParentPlayer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ParentPlayer = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position.x - ParentPlayer.transform.position.x) < 20)
        {
            anim.SetTrigger("start");
        }
    }
}
