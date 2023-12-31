using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UfoBehavior : MonoBehaviour
{
    public float health;
    private float baseHp;
    public int speed = 3;
    public GameObject healthbar;
    public GameObject healthHealthBar;
    private GameObject enemySpawner;
   
    // Start is called before the first frame update
    void Start()
    {
        baseHp = health;
        enemySpawner=GameObject.FindGameObjectsWithTag("EnemySpawner")[0];
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
            transform.GetChild(4).gameObject.SetActive(false);
            StartCoroutine(die());
            //gameObject.SetActive(false);
        }
        if (health > 0)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
            healthHealthBar.transform.localScale = new Vector3((health / baseHp), healthHealthBar.transform.localScale.y, healthHealthBar.transform.localScale.z);
            healthHealthBar.transform.localPosition = new Vector3(-0.15f - (1 - healthHealthBar.transform.localScale.x), 0.82f, 0f);
        }

    }
    IEnumerator die()
    {
        givemoney();
        yield return new WaitForSeconds(1.2f);
        this.gameObject.SetActive(false);
    }
    public void givemoney()
    {
        //TODO: add money multiplier based on stage numnber
        money.moneyAmount += (int)(1 * Mathf.Round(enemySpawner.GetComponent<EnemySpawning>().stage/3f));
        
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Bullet")
        {
            health -= 1;
        }
        if(c.tag=="LaserBullet"){
            health-=0.1f;
        }
        if (c.tag == "Earth" && health > -100000)
        {
            ParticleSystem ps = transform.GetChild(3).GetComponent<ParticleSystem>();
            ps.Play();
            health = -100000;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            StartCoroutine(die());
        }
    }
}
