using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 20;
    private int timetoLive = 250;

    // Update is called once per frame
    void Update()
    {
        // Decrement the time to live
        timetoLive--;

        // Check if the time to live has expired
        if (timetoLive <= 0)
        {
            Destroy(gameObject);
            return; // Exit the method to prevent further movement
        }

        // Move the bullet
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
