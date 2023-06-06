using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private float _speed;
    private float _range;
    private ITargetable _target;
    private Rigidbody2D _rb;
    private Vector2 _towerPosition;


    public ITargetable Target => _target;
    public float Damage => Damage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(TowerData data)
    {
        _damage = data.damage;
        _speed = data.projectileSpeed;
        _range = data.range;
        _towerPosition = transform.position;
        _target = GetClosestTarget();
    }

    private void Update()
    {
        var target = _target as MonoBehaviour;
        if (target != null)
        {
            Vector2 targetPosition = _target.Transform.position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            Vector2 velocity = direction * _speed * Time.deltaTime;
            _rb.velocity = velocity;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected ITargetable GetClosestTarget()
    {
       // IEnumerable<ITargetable> targetObjects = FindObjectsOfType<MonoBehaviour>().OfType<ITargetable>(); //expensive op

        var hits = Physics2D.CircleCastAll(_towerPosition, _range, Vector2.zero);

        if (hits == null)
            return null;
        
        ITargetable[] targets = hits.Select(hit => hit.collider.gameObject.GetComponent<ITargetable>()).OfType<ITargetable>().ToArray();




        ITargetable closestObject = null;
        float closestDistance = float.MaxValue;

        foreach (ITargetable targetObject in targets)
        {
            Vector2 targetPosition = targetObject.Transform.position;
            float distance = Vector2.Distance(_towerPosition, targetPosition);

            if (distance <= _range && distance < closestDistance)
            {
                closestObject = targetObject;
                closestDistance = distance;
            }
        }

        return closestObject;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ITargetable _))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();


                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(_damage);
                    Destroy(gameObject);
                }

            }
        }
        Destroy(gameObject);
    }



}
