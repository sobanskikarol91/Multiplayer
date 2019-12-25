using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tank : MonoBehaviour
{
    private PCMovement movement;

    private void Awake()
    {
        movement = GetComponentInChildren<PCMovement>();
    }

    private void Update()
    {
        movement.Execute();
    }
}