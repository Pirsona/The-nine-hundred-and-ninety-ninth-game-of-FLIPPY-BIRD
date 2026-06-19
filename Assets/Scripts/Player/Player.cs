using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Attack _attack;

    private bool _isDead = false;
    
    private void Update()
    {
        if(_playerInput.IsJump)
        {
            _playerMovement.Jump();
            Debug.Log("Jump");
            _playerInput.ConsumeJump();
        }
        
        if (_playerInput.IsShoot)
        {            
            _attack.Shoot();
            Debug.Log("Shoot");
            _playerInput.ConsumeShoot();
        }
    }

    private void FixedUpdate()
    {
        if(_playerInput.IsJump)
        {
            _playerMovement.Jump();
            Debug.Log("Jump");
            _playerInput.ConsumeJump();
        }

    }
}