using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float runSpeed;
    private Vector3 v3 = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += v3 * runSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("GroundLeftBorder") || collision.gameObject.CompareTag("GroundRightBorder")
            || collision.gameObject.CompareTag("Enemy1"))
        {
            if (v3 == Vector3.left)
            {
                v3 = Vector3.right;
            }
            else
            {
                v3 = Vector3.left;
            }

            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
