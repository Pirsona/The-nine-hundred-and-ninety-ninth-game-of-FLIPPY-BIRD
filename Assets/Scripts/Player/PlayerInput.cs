using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootKey = KeyCode.E;
    
    public bool IsJumping { get; private set; } = false;
    public bool IsShooting { get; private set; } = false;

    private void Update()
    {
        CheckInput();
    }
    
    private void CheckInput()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            IsJumping = true;
        }

        if (Input.GetKeyDown(_shootKey))
        {
            IsShooting = true;
        }
    }

    public void ConsumeJump()
    {
        IsJumping = false;
    }

    public void ConsumeShoot()
    {
        IsShooting = false;
    }
}