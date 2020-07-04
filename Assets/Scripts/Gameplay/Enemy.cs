using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.5f;
    Player playerComponent;

    private void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            playerComponent.AddScore(10);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && playerComponent != null)
        {
            if (playerComponent.SheildActivated)
            {
                playerComponent.SheildActivated = false;
                playerComponent.transform.GetChild(0).gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                playerComponent.Damage();
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -5f)
        {
            transform.position= new Vector3(Random.Range(-9f, 9f), 10, 0);
        }
    }
}
