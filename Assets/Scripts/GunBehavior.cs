using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var enemyCount = enemies.Length;
        foreach (var enemy in enemies)
        {
        // check distance
            float distanceBetweenObjects = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceBetweenObjects <= range) {
                enemy.GetComponent<UfoBehavior>().hp -= 1;
            }
            
        }
    }
}
