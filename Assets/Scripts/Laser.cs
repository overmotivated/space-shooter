using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        //Vector3 direction;
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > 7)
        {
           Destroy(gameObject, 2f);
        }
    }
}
