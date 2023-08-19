using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<2000;i++){
            float x=Random.Range(-20f, 100f);
            float z=Random.Range(-20f, 20f);
            Instantiate(star,new Vector3(x,0,z),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
