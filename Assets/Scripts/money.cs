using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    // Start is called before the first frame update
    public int moneyAmount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void givemoney()
    {
        //TODO: add money multiplier based on stage numnber
        moneyAmount += 1 * enemySpawner.GetComponent<EnemySpawning>.enemyHealthscaling;
    }

    public bool buyKinetic()
    {
        if (moneyAmount >= 10)
        {
            moneyAmount -= 10;
            return true;
        }
        return false;
    }

    public bool buyLaser()
    {
        if (moneyAmount >= 20)
        {
            moneyAmount -= 20;
            return true;
        }
        return false;
    }
}
