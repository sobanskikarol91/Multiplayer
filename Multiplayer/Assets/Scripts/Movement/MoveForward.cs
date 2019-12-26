using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed;

    private void Awake()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.position +=  transform.up * speed * Time.deltaTime;
    }
}