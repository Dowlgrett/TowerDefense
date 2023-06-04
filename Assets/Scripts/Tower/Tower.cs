using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected float _range;
    protected float _damage;
    protected float _attackSpeed;
    protected float _projectileSpeed;
    public float Damage => _damage;

    protected Projectile _projectilePrefab;

    public float ProjectileSpeed => _projectileSpeed;


    protected bool _canAttack;

    [SerializeField]
    protected TowerData _towerData;

    protected virtual void Start()
    {
        _range = _towerData.range;
        _damage = _towerData.damage;
        _attackSpeed = _towerData.attackSpeed;
        _projectileSpeed = _towerData.projectileSpeed;
        _canAttack = true;
        _projectilePrefab = Resources.Load<Projectile>("Prefabs/Projectile");
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(_attackSpeed);
        _canAttack = true;
    }



    protected void SpawnProjectile()
    {
        if (_canAttack)
        {           
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.Initialize(_towerData);
            _canAttack = false;
            StartCoroutine(AttackCooldown());
        }
       
    }


}


