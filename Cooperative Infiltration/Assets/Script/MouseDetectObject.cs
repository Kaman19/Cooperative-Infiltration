using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetectObject : MonoBehaviour
{



    // The distance from the camera for the projection
    public float distanceFromCamera = 10;

    // The resulting mouse position
    public Vector3 mouseInWorld = new Vector3();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get the screen position :
        Vector3 mouseInScreen = Input.mousePosition;

        // Set the distance from the camera :
        mouseInScreen.z = distanceFromCamera;

        // Get the world position :
        mouseInWorld = Camera.current.ScreenToWorldPoint(mouseInScreen);

        // Print the world position in the console :
        Debug.Log(mouseInWorld);


    }
}
