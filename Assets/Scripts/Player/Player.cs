using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDeath _death;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Attacker _attacker;
    
    private void Update()
    {
        if (_death.IsDead == false)
        {
            if (_playerInput.IsShooting)
            {            
                _attacker.Shoot();
                _playerInput.ConsumeShoot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_death.IsDead == false)
        {
            if(_playerInput.IsJumping)
            {
                _playerMovement.Jump();
                _playerInput.ConsumeJump();
            }
        }
    }
}