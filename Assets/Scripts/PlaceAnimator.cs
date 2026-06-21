using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlaceAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        _animator.enabled = true;
    }

    public void StopAnimation()
    {
        _animator.enabled = false;
    }
}
