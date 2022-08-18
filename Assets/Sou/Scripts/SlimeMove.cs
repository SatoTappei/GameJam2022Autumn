using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float moveSpeed;

    private Vector3 _moveVelocity;
    private Transform _transform;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        _characterController.Move(_moveVelocity * Time.deltaTime);

        _animator.SetFloat("moveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}
