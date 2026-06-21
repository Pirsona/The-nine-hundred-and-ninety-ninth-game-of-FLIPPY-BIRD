using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDeath _death;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Attack _attack;
    
    private void Update()
    {
        if (_death.IsDead == false)
        {
            if (_playerInput.IsShoot)
            {            
                _attack.Shoot();
                _playerInput.ConsumeShoot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_death.IsDead == false)
        {
            if(_playerInput.IsJump)
            {
                _playerMovement.Jump();
                _playerInput.ConsumeJump();
            }
        }
    }
}