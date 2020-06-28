using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private GameObject Player;
    [SerializeField]
    private Vector2 tripleShotDuration;

    private void Start()
    {
        Player = GameObject.Find("Player");
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
            other.GetComponent<Fire>().TrippleShotBufActivate(tripleShotDuration);
            Destroy(gameObject);
        }
    }
}
