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
        if (enemyCount > 0)
        {
            var target = closeistTarget(enemies);
            var distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < range)
            {
                transform.LookAt(target.transform);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
            }
        }


    }

    public GameObject closeistTarget(GameObject[] enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }


}
