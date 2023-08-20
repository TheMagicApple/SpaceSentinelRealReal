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
                float[] badPoints={-13.9f,-5.62f,4.05f,-4.3f,-4.57f,-0.7f,8.05f,3.76f,2.04f,11.97f,-3.78f,-14.32f,11.12f,27.42f,19.64f,2.73f,24.19f,40.12f,-4.77f,-21.15f,34.31f,42.42f,11.24f,2.51f};
                
                Vector3 worldPosition = ray.GetPoint(distance);
                if(turret=="turret" && money.moneyAmount>=2){
                    Vector3 goodpos=worldPosition;
                    float x=goodpos.x;
                    float z=goodpos.z;
                    bool good=false;
                    for(int i=0;i<badPoints.Length;i+=4){
                        if(x>=badPoints[i] && x<=badPoints[i+1] && z>=badPoints[i+3] && z<=badPoints[i+2]){
                            good=true;
                            break;
                        }
                    }
                    if(good){
                       
                        Instantiate(turrt,goodpos+3*transform.up,Quaternion.identity);
                        money.moneyAmount-=2;
                    }
                    
                    
                } 
                else if(turret=="laser" && money.moneyAmount>=9){
                    Vector3 goodpos=worldPosition;
                    float x=goodpos.x;
                    float z=goodpos.z;
                    bool good=false;
                    for(int i=0;i<badPoints.Length;i+=4){
                        if(x>=badPoints[i] && x<=badPoints[i+1] && z>=badPoints[i+3] && z<=badPoints[i+2]){
                            good=true;
                            break;
                        }
                    }
                    if(good){
                        Instantiate(lasr,worldPosition-13*transform.up-288*transform.forward-0*transform.right,Quaternion.identity);
                        money.moneyAmount-=9;
                    }
                    
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
