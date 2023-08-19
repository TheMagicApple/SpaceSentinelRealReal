using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private LineRenderer lr;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) 
        {
            if (hit.collider) 
            {
                lr.SetPosition(1, hit.point);
                if (hit.transform.gameObject.tag == "Enemy") {
                    hit.transform.gameObject.GetComponent<UfoBehavior>().health -= power;
                }
            }
        }
        else lr.SetPosition(1, transform.forward*5000);
    }
}
