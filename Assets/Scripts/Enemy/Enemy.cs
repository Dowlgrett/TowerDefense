using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITargetable
{
    [SerializeField]
    protected EnemyData _enemyData;
    public Transform Transform => transform;


    protected float _speed;
    protected int _goldReward;
    protected float _damage;
    protected float _health;
    protected Rigidbody2D _rb;
    public float Health => _health;



    public virtual void TakeDamage(float amount)
    {
        _health -= amount;
    }



    protected virtual void Start()
    {
        _speed = _enemyData.speed;
        _goldReward = _enemyData.goldReward;
        _damage = _enemyData.damage;
        _health = _enemyData.health;
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update() 
    {
        if (_health <= 0 && gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    protected void FixedUpdate()
    {
        ChasePlayer();
    }





    protected Vector2 GetVectorTowardsPlayer()
    {
        GameObject player = GameObject.Find("Player");
        Vector2 playerPosition = player.transform.position;
        return (playerPosition - (Vector2)transform.position).normalized;

    }
    protected void ChasePlayer()
    {
        _rb.velocity = GetVectorTowardsPlayer() * _speed;
    }


}
