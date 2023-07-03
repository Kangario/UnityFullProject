using UnityEngine;
using System.Collections.Generic;

public class InventarVieu : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(); // ������ ��������� � ���������

    // ����� ��� ���������� �������� � ���������
    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("�������� ������� � ���������: " + item.name);
    }

    // ����� ��� �������� �������� �� ���������
    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Debug.Log("������ ������� �� ���������: " + item.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Item"))
        {
            AddItem(other.gameObject);
            other.transform.position = new Vector3(0, -90, 0);
        }
    }
   
}