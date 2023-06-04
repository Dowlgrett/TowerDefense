using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField]
    private GameObject objectToSpawn;

    private int _gold = 0;
    public int Gold { get; }

    [SerializeField]
    private float _health = 100;
    public float Health => _health;

    private PlayerMovement _movement;
    private Rigidbody2D _rb;



    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
       _rb = GetComponent<Rigidbody2D>();      
    }

    void FixedUpdate()
    {
        _rb.velocity = _movement.GetMovementVector();
    }


}
