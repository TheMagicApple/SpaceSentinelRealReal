using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);
    public GameObject turrt;
    public GameObject lasr;
    private string turret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                Vector3 worldPosition = ray.GetPoint(distance);
                if(turret=="turret") Instantiate(turrt,worldPosition+3*transform.up,Quaternion.identity);
                else Instantiate(lasr,worldPosition-13*transform.up-288*transform.forward-0*transform.right,Quaternion.identity);
            }
        }
        
    }
    public void turt(){
        turret="turret";
    }
    public void laser(){
        turret="laser";
    }
}
