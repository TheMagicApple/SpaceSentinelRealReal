using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private LineRenderer lr;
    public int power;
    public int range;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var enemyCount = enemies.Length;
        if (enemyCount > 0)
        {
            var target = closeistTarget(enemies);
            var distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < range)
            {
                 lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                lr.SetPosition(1, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
                target.gameObject.GetComponent<UfoBehavior>().health -= power;
            }
            else
            {

                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


        //else lr.SetPosition(1, transform.forward*5000);
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
}
