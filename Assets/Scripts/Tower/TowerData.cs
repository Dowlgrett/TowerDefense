using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData")]
public class TowerData : ScriptableObject
{
    public float range;
    public int damage;
    public float attackSpeed;
    public float projectileSpeed;
}

