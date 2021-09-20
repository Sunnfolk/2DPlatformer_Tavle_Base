using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsGround;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public bool IsGrounded()
    {
        var position = transform.position;
        
        Debug.DrawRay(position, Vector2.down, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, Vector2.down, 1.1f, whatIsGround);
        return hit.collider != null;
    }
}