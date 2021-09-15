using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private PlayerInput m_Input;
    
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (m_Input.moveVector.x != 0)
        {
            m_Animator.Play("Player_Run");
            transform.localScale = new Vector2(m_Input.moveVector.x * 1f, 1f);
        }
        else
        {
            m_Animator.Play("Player_Idle");
        }
    }
}