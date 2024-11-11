using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _target;
    [SerializeField] private float _distanceToTarget = 1f;

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 target = _target.transform.position;

        if (IsTargetReached() != true)
        {
            _rigidbody.position = Vector3.MoveTowards(_transform.position, target, _speed * Time.deltaTime);
        }
    }

    public bool IsTargetReached()
    {
        return transform.position.IsEnoughClose(_target.transform.position, _distanceToTarget);
    }
}
