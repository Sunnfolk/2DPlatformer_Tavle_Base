using PlayerScripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class EasyCheckPoint : MonoBehaviour
{
    private static Vector2 _SavedPosition;
    public static GameObject player;
    [SerializeField] private GameObject _player;

    public GameObject _ps;
    private void Start()
    {
        player = _player;
        SavePlayerPosition();
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ResetPlayerPosition();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        SavePlayerPosition();
        PlayerParticles.CreateConfetti();
    }

    public void ResetPlayerPosition()
    {
        player.transform.position = _SavedPosition;
    }

    private void SavePlayerPosition()
    {
        _SavedPosition = player.transform.position;
    }
}