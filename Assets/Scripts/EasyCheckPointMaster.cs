using System;
using UnityEngine;

public class EasyCheckPointMaster : MonoBehaviour
{
    public static Vector2 savedPosition;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        savedPosition = player.transform.position;
    }
}
