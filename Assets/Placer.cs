using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Placer : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);
    public GameObject turrt;
    public GameObject lasr;
    private string turret;
    bool clicked=false;
    public GameObject next;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length==0){
            next.SetActive(true);
        }else{
            next.SetActive(false);
        }
        if(Input.GetMouseButtonDown(0) && GameObject.FindGameObjectsWithTag("Enemy").Length>0 && !(Input.mousePosition.x<400 && Input.mousePosition.y<160)){
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                Vector3 worldPosition = ray.GetPoint(distance);
                if(turret=="turret" && money.moneyAmount>=2){
                    Instantiate(turrt,worldPosition+3*transform.up,Quaternion.identity);
                    money.moneyAmount-=2;
                    
                } 
                else if(turret=="laser" && money.moneyAmount>=9){
                    Instantiate(lasr,worldPosition-13*transform.up-288*transform.forward-0*transform.right,Quaternion.identity);
                    money.moneyAmount-=9;
                    
                } 
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
