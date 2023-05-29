using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using WebXR;
using Zinnia.Action;

public class WebFloatX : FloatAction
{
    public WebXRController controller;  // Object to hold controller
    public float xInput;    // Stores controller input

    // Update is called once per frame
    void Update()
    {
        var Vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick); // Get thumbstick horizontal input as vector2
        xInput = Vector2.x; // Set float to store value.
        Receive(xInput);    // Receive controller input

    }
}
