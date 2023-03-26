using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;

    private int xLength = 200;
    private int yLength = 200;
    private System.Random rand;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount == 0 && count < 3)
        {
            count++;
            spawnEnemies();
        }
    }

    private void spawnEnemies()
    {
        for (int i = 0; i < 3; i++)
        {
            int x = rand.Next(10, xLength - 9);
            int y = rand.Next(10, yLength - 9);
            for (int j = 0; j < 3; j++)
            {
                int xOffset = rand.Next(-10, 11);
                int yOffset = rand.Next(-10, 11);
                int enemyType = rand.Next(1, 4);

                switch (enemyType)
                {
                    case 1:
                        var enemy1 = Instantiate(this.enemy1);
                        enemy1.transform.position = new Vector3(x + xOffset, y + yOffset, 0);
                        enemy1.transform.parent = gameObject.transform;
                        break;
                    case 2:
                        var enemy2 = Instantiate(this.enemy2);
                        enemy2.transform.position = new Vector3(x + xOffset, y + yOffset, 0);
                        enemy2.transform.parent = gameObject.transform;
                        break;
                    case 3:
                        var enemy3 = Instantiate(this.enemy3);
                        enemy3.transform.position = new Vector3(x + xOffset, y + yOffset, 0);
                        enemy3.transform.parent = gameObject.transform;
                        break;
                    default:
                        break;
                }


            }
        }
    }


}
