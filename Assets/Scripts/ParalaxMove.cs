using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMove : MonoBehaviour
{
    public float parallaxEffect;

    private GameObject camera;
    private float positionX;
    private float cameraPositionX;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        positionX = transform.position.x;
        cameraPositionX = camera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = camera.transform.position.x - cameraPositionX;
        float parallaxDistance = distance * parallaxEffect;

        transform.position = new Vector3(positionX + parallaxDistance, transform.position.y, transform.position.z);
    }
}
