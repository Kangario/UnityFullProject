using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="MyItems/Items")]
public class Items : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float radiusAttack;
}
