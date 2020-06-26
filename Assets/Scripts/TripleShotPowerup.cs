using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

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
}
