using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawning : MonoBehaviour
{
    public float difficultyScale;
    public int stage;
    public GameObject enemy;
    public static readonly int BASE_ENEMY_HEALTH = 5; // Use 'readonly' and specify the type
    public TMP_Text round;
    // Start is called before the first frame update
    void Start()
    {

        stage = 1;
        difficultyScale = 0.5f; // Correct variable name and use 'float'
        spawnEnemies();
    }

    public int enemyHealthscaling(int Stage) // Correct function name
    {
        return Mathf.RoundToInt(Stage * difficultyScale); // Use Mathf.RoundToInt
    }

    public int enemyNumber(int Stage)
    {
        return Mathf.RoundToInt((2 * Stage) + 3); // Use Mathf.RoundToInt
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnEnemies()
    {
        for (int i = 0; i < enemyNumber(stage); i++)
        {
            //Instantiate(enemy, new Vector3(53.7f, 0, 0), Quaternion.Euler(0, 0, 0));
            // set enemy health to enemyHealthscaling(stage)
            GameObject e = Instantiate(enemy, new Vector3(53.7f + i * 5, 0, Random.Range(-2.5f, 1.5f)), Quaternion.identity);
            e.GetComponent<UfoBehavior>().health = BASE_ENEMY_HEALTH * enemyHealthscaling(stage);
             e.GetComponent<UfoBehavior>().speed= 3+(stage-2);
        }
        stage++;
        round.text="Round "+(stage-2);
    }
}
