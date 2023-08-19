using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public float range;
    public int power;
    public int reloadTime;
    private int timer;

    private GameObject upgradedObject;
    public GameObject upgradePrefab;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    void FixedUpdate()
    {
        timer++;

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var enemyCount = enemies.Length;
        foreach (var enemy in enemies)
        {
        // check distance
            float distanceBetweenObjects = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceBetweenObjects <= range) 
            {
                //check timer
                if (timer >= reloadTime) {
                    enemy.GetComponent<UfoBehavior>().hp -= 1;
                    timer = 0;
                }
            }
            
        }
    }

    void Upgrade() {
        upgradedObject = Instantiate(upgradePrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }


}
