using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeStar : MonoBehaviour
{
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<20;i++){
            Instantiate(star,new Vector3(Random.Range(-88f,88f),Random.Range(-45f,50f),78.4f),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play(){
        SceneManager.LoadScene("Game");
    }
}
