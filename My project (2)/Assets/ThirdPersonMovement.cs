using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float groundRaycastDistance = 1.5f; // Adjust this based on your character's size

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        // Raycast to adjust character's position based on terrain elevation
        AdjustPositionToTerrain();
    }

    void AdjustPositionToTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRaycastDistance))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y; // Set the Y position to the terrain's height
            transform.position = newPosition;
        }
    }
}
