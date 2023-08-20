using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }

    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Enemy") {
            hp -= 1;
            healthbar.transform.localScale = new Vector3(4.31f*(hp/baseHp), healthbar.transform.localScale.y, healthbar.transform.localScale.z);


        }
    }
}
