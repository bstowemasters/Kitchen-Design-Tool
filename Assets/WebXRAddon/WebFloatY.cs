using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using WebXR;
using Zinnia.Action;

public class WebFloatY : FloatAction
{
    public WebXRController controller;  // Object to hold controller
    public float yInput;    // Stores controller input

    // Update is called once per frame
    void Update()
    {
        var Vector2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick); // Get thumbstick horizontal input as vector2
        yInput = Vector2.y; // Set float to store value.
        Receive(yInput);    // Receive controller input

    }
}
