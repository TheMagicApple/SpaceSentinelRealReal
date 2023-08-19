using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public float range;
    public int power;
    public int reloadTime;// in ticks
    private int timer;
    private int turingSpeed;//deg/tick

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
        if (enemyCount > 0)
        {
            var target = closeistTarget(enemies);
            var distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < range + 10)
            {
                Vector3 targetDir = target.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turingSpeed * Time.deltaTime);
                //transform.LookAt(target.transform);

                if (timer >= reloadTime && distance < range)
                {
                    target.GetComponent<UfoBehavior>().health -= power;
                    timer = 0;
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


    }

    public GameObject closeistTarget(GameObject[] enemies)
    {
        GameObject closeistTarget = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, currentPos);
            if (dist < minDist)
            {
                closeistTarget = enemy;
                minDist = dist;
            }
        }
        return closeistTarget;
    }

    void Upgrade()
    {
        upgradedObject = Instantiate(upgradePrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }


}
