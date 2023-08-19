using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarthScript : MonoBehaviour
{
    public int hp;
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textObj.GetComponent<TextMeshProUGUI>().text = "Health: " + hp;

    }

    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Enemy") {
            hp -= 1;
        }
    }
}
