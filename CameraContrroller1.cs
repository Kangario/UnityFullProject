using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using TMPro;
public class CameraContrroller1 : MonoBehaviour
{
    private CinemachineVirtualCamera vm;
    [SerializeField] private Transform target;
    [Range(0f, 100f)]
    [SerializeField] private float distance = 10f;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float xSpeed = 250f;
    [SerializeField] private float ySpeed = 120f;
    private float x = 0f;
    private float y = 0f;
    private void Start()
    {
        vm = GetComponent<CinemachineVirtualCamera>();
    }
    private void LateUpdate()
    {

            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
          //  y = Mathf.Clamp(y, 0f, 45f);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            target.rotation = rotation;
            distance= Mathf.Clamp(distance, minDistance,maxDistance);
            vm.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = distance;
            distance -= Input.GetAxis("Mouse ScrollWheel") * 5f;
    }
}
