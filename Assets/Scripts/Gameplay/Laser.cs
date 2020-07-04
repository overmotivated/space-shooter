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
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > 7)
        {
            Transform parent = transform.parent;
            if (parent != null)
            {
                Destroy(parent.gameObject, 0.8f);
            }

            Destroy(gameObject, 0.8f);
        }
    }
}
