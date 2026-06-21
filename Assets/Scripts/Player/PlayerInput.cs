using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootKey = KeyCode.E;
    
    public bool IsJump { get; private set; } = false;
    public bool IsShoot { get; private set; } = false;

    private void Update()
    {
        CheckInput();
    }
    
    private void CheckInput()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            IsJump = true;
        }

        if (Input.GetKeyDown(_shootKey))
        {
            IsShoot = true;
        }
    }

    public void ConsumeJump()
    {
        IsJump = false;
    }

    public void ConsumeShoot()
    {
        IsShoot = false;
    }
}