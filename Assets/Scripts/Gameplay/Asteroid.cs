using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.3f;
    private CircleCollider2D circleColl;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject explosion;
    public event Action AsteroidDestroyed;

    void Start()
    {
        circleColl = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyAsteroid();
        }
        else if (other.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            DestroyAsteroid();
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void DestroyAsteroid()
    {
        circleColl.enabled = false;
        Debug.Log("from DestroyAsteroid");
        AsteroidDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
