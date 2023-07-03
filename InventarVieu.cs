using UnityEngine;
using System.Collections.Generic;

public class InventarVieu : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(); // Список предметов в инвентаре

    // Метод для добавления предмета в инвентарь
    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("Добавлен предмет в инвентарь: " + item.name);
    }

    // Метод для удаления предмета из инвентаря
    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Debug.Log("Удален предмет из инвентаря: " + item.name);
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