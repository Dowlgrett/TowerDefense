using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingValidator
{
    [SerializeField]
    private static float _buildingRange = 40f;


    public bool CanBuild(Vector2 buildingPosition)
    {
        Player player = Object.FindObjectOfType<Player>();
        float distance = Vector2.Distance(player.transform.position, buildingPosition);
        return distance <= _buildingRange;

    }

}
