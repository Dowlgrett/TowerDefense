using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTower : Tower
{
    protected override void Start()
    {
        base.Start();
    }


    private void Update()
    {
        SpawnProjectile();

    }


}
