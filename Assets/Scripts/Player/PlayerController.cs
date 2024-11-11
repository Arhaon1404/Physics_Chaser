using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_characterController != null)
        {
            float axisX = Input.GetAxis("Horizontal");
            float axisY = 0;
            float axisZ = Input.GetAxis("Vertical");

            Vector3 playerSpeed = new Vector3(axisX, axisY, axisZ);
            playerSpeed *= Time.deltaTime * _speed;

            if (_characterController.isGrounded)
            {
                _characterController.Move(playerSpeed + Vector3.down);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Vector3.down * Time.deltaTime);
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(_characterController));
        }
    }
}
