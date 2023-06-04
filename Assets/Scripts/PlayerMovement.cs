using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;

    [SerializeField]
    private float _speed = 10f;




    public Vector3 GetMovementVector()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");  
        Vector2 moveDirection = new Vector2(_horizontalInput, _verticalInput).normalized;
        return moveDirection * _speed;
    }


    
   

}
