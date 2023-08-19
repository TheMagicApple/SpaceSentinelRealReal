using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private bool movingLeft=false;
    private bool movingRight=false;
    private bool movingForward=false;
    private bool movingBackward=false;
    private int speed=13;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(down("w")) movingForward=true;
        if(down("a")) movingLeft=true;
        if(down("s")) movingBackward=true;
        if(down("d")) movingRight=true;
        if(up("w")) movingForward=false;
        if(up("a")) movingLeft=false;
        if(up("s")) movingBackward=false;
        if(up("d")) movingRight=false;
        if(movingLeft) transform.position-=transform.right*Time.deltaTime*speed;
        if(movingRight) transform.position+=transform.right*Time.deltaTime*speed;
        if(movingForward) transform.position+=new Vector3(transform.forward.x,0,transform.forward.z)*Time.deltaTime*speed;
        if(movingBackward) transform.position-=new Vector3(transform.forward.x,0,transform.forward.z)*Time.deltaTime*speed;

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            transform.position+=new Vector3(0f,transform.forward.y,0f)*Time.deltaTime*speed;
        }
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            transform.position+=new Vector3(0f,transform.forward.y*-1,0f)*Time.deltaTime*speed;
        }
    }
    bool down(string key){
        return Input.GetKeyDown(key);
    }
    bool up(string key){
        return Input.GetKeyUp(key);
    }
}
