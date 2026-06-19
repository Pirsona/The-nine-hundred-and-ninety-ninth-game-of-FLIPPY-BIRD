using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    
    private Rigidbody _playerRB;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        _playerRB.velocity = new Vector3(_playerRB.velocity.x, 0f, _playerRB.velocity.z);
        _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
