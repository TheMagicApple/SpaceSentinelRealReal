using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    // Start is called before the first frame update
    public static int moneyAmount;

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
        moneyAmount += 1 * round(enemySpawner.GetComponent<EnemySpawning>.stage / 3f);
    }


}
