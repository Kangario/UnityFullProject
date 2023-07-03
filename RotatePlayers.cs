using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayers : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 lookDirection;
    private CharacterController controller;
  
    void Start()
    {
        controller = GetComponent<CharacterController>();
        lookDirection = transform.forward;
        
    }

   
    void Update()
    {
        Vector3 cameraForward = camera.forward;
        cameraForward.y = 0;
        lookDirection = Vector3.Slerp(lookDirection, cameraForward, Time.deltaTime * rotationSpeed);
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
