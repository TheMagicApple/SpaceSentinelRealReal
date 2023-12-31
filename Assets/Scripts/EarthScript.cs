using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EarthScript : MonoBehaviour
{
    public int hp;
    private float baseHp;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        baseHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
            money.moneyAmount=0;
            SceneManager.LoadScene("Home");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            hp -= 1;
            healthbar.transform.localScale = new Vector3(4.31f*(hp/baseHp), healthbar.transform.localScale.y, healthbar.transform.localScale.z);
            healthbar.transform.localPosition=new Vector3((4.31f-healthbar.transform.localScale.x)*-150,healthbar.transform.localPosition.y,healthbar.transform.localPosition.z);

        }
    }
}
