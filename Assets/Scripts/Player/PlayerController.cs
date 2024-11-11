using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private string _horizontalAxis;
    private string _verticalAxis;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _horizontalAxis = "Horizontal";
        _verticalAxis = "Vertical";
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float axisX = Input.GetAxis(_horizontalAxis);
        float axisY = 0;
        float axisZ = Input.GetAxis(_verticalAxis);

        Vector3 playerSpeed = new Vector3(axisX, axisY, axisZ);
        playerSpeed *= Time.deltaTime * _speed;

        if (_characterController.isGrounded)
        {
            _characterController.Move(playerSpeed + Physics.gravity);
        }
        else
        {
            _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
    }
}
