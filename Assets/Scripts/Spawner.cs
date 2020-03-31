using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pigs;

    public Animator animator;

    private float nextSpawn = 0;
    private float waveTimer = 0;
    public float spawnRate = 1f;
    public float waveDuration = 60f;
    public int wave = 0;
    public int numOfEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Open", true);
        waveTimer += waveDuration;
        nextSpawn = spawnRate;
        wave++;
        numOfEnemies = wave;
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
        if ((nextSpawn <= 0) && (numOfEnemies >= 1))
        {
            Instantiate(pigs[Random.Range(0, 3)], transform);
            numOfEnemies--;
            nextSpawn += spawnRate;
        } 
        else if (numOfEnemies == 0)
        {
            animator.SetBool("Open", false);
        }

        if (waveTimer <= 0)
        {
            animator.SetBool("Open", true);
            waveTimer += waveDuration;
            nextSpawn = spawnRate;
            wave++;
            numOfEnemies = wave;
        }
    }
}
