using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UfoBehavior : MonoBehaviour
{
    public int health;
    private int baseSpeed = 3;
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        transform.position -= transform.right * Time.deltaTime * speed;
        textObj.GetComponent<TextMeshPro>().text = health.ToString();
    }
}
