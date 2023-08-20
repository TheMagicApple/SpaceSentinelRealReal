using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior2 : MonoBehaviour
{
    public float range;
    public int power;
    public int reloadTime;// in ticks
    private int timer;

    private GameObject upgradedObject;
    public GameObject upgradePrefab;
    public GameObject bullet;
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
            if (distance < range)
            {
                transform.LookAt(new Vector3(target.transform.position.x-2,transform.position.y,target.transform.position.z));
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
                if (timer >= reloadTime)
                {
                    Debug.Log(transform.localEulerAngles.y);
                    Instantiate(bullet,transform.position,Quaternion.Euler(new Vector3(transform.eulerAngles.x,transform.localEulerAngles.y+90,transform.eulerAngles.z)));
                   // target.GetComponent<UfoBehavior>().health -= power;
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
