using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private PowerupManager PowerupManager;
    [SerializeField]
    private PowerupEnum powerupEnum;

    private void Start()
    {
        PowerupManager = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerupManager.UsePowerup(powerupEnum);
        }
    }
}
