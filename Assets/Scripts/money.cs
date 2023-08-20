using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class money : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text mony;
    public static int moneyAmount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mony.text="$"+money.moneyAmount+"M";
    }

    public void givemoney()
    {
        //TODO: add money multiplier based on stage numnber
        //moneyAmount += 1 * enemySpawner.GetComponent<EnemySpawning>.enemyHealthscaling;
    }


}
