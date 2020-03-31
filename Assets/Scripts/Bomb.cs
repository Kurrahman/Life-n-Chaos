using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionTemplate;
    private GameObject explosion;
    // Start is called before the first frame update
    private void Start()
    {
        explosion = Instantiate(explosionTemplate);
        explosion.SetActive(false);
    }
    private void OnEnable()
    {
        explosion.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.transform.position = gameObject.transform.position;
        explosion.SetActive(true);
        gameObject.SetActive(false);
    }
}
