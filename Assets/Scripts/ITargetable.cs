using System;
using UnityEngine;

public interface ITargetable
{
    public float Health { get; }
    public Transform Transform { get; }

    public void TakeDamage(float amount);
}