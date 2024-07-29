using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShellScript : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjustable rotation speed

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // Rotate the shell around the Z-axis for 2D rotation
    }
}