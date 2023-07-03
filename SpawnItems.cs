using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public Inventar[] objectts;
    bool isSpawn = true;


    public void SpawnItem()
    {   
       
        GameObject prefab = new GameObject();



        prefab.AddComponent<MeshFilter>().mesh = objectts[0].meshItem;
        prefab.AddComponent<MeshRenderer>();
        prefab.AddComponent<BoxCollider>().isTrigger = true;

        prefab.CompareTag("Item");




        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    void Start()
    {
        
    }

   
    void Update()
    {   
        if (gameObject.GetComponent<Stats>().hp<=0 && isSpawn == true)
        {
            SpawnItem();
            isSpawn= false;
        }
    }
}
