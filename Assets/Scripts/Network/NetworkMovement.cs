using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkMovement : NetworkBehaviour
{
    public float Speed;

    private IInput _input;
    private CharacterController characterController;
    private Animator _animator;

    public override void OnStartLocalPlayer()
    {
       
        characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();

        _input = GetComponent<IInput>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        var horizontal = _input.HorizontalAcceleration;
        var vertical = _input.VerticalAcceleration;
        var direction = new Vector3(horizontal, 0f, vertical);
        transform.Translate(direction * Time.deltaTime * Speed);

        if(direction.magnitude > 0.2f)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }
}
