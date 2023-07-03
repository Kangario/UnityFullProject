using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diology : MonoBehaviour
{
    public GameObject text;
    bool isDiology;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDiology && Input.GetKeyUp(KeyCode.E))
        {
            text.SetActive(true);
        }
        if (isDiology == false)
        {
            text.SetActive(false);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDiology = true;
            // �������� ����� � �������
            Debug.Log("�������� ����� � �������");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isDiology = false;
            // �������� ����� �� �������
            Debug.Log("�������� ����� �� �������");
        }
    }
}
