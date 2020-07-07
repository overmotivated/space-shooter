using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Explosion1");
        Destroy(gameObject, 2.5f);
        Debug.Log("Explosion2");
    }
}
