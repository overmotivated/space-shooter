using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.5f;
    private Player playerComponent;
    private Animator animComponent;
    private BoxCollider2D boxColl;

    private void Start()
    {
        playerComponent = GameObject.Find("Player").GetComponent<Player>();
        animComponent = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();
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
            Destroy();
        }
        else if (other.CompareTag("Player") && playerComponent != null)
        {
            if (playerComponent.SheildActivated)
            {
                playerComponent.SheildActivated = false;
                playerComponent.transform.GetChild(0).gameObject.SetActive(false);
                Destroy();
            }
            else
            {
                playerComponent.Damage();
                Destroy();
            }
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -5f)
        {
            transform.position= new Vector3(Random.Range(-9f, 9f), 14, 0);
        }
    }

    private void Destroy()
    {
        float decreaseSpeed = 0.7f;
        animComponent.Play("EnemyExplosion");
        boxColl.enabled = false;
        StartCoroutine(speedDecreasing(decreaseSpeed));
        Destroy(gameObject, 2.8f);
    }

    IEnumerator speedDecreasing(float decreaseSpeed)
    {
        yield return new WaitForSeconds(0.5f);
        speed = speed * decreaseSpeed;
        yield return new WaitForSeconds(0.5f);
        speed = speed * decreaseSpeed;
        yield return new WaitForSeconds(0.5f);
        speed = speed * decreaseSpeed;
        yield return new WaitForSeconds(0.5f);
        speed = speed * decreaseSpeed;
        yield return new WaitForSeconds(0.5f);
        speed = speed * decreaseSpeed;
    }
}
