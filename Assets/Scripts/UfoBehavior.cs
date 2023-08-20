using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UfoBehavior : MonoBehaviour
{
    public int health;
    private int speed = 3;
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && health > -100000)
        {
            ParticleSystem ps = transform.GetChild(3).GetComponent<ParticleSystem>();
            ps.Play();
            health = -100000;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            StartCoroutine(die());
            //gameObject.SetActive(false);
        }
        if (health > 0) transform.position -= transform.right * Time.deltaTime * speed;
        textObj.GetComponent<TextMeshPro>().text = health.ToString();
    }
    IEnumerator die()
    {
        shmoney.GetComponent<money>().givemoney();
        yield return new WaitForSeconds(1.2f);
        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
