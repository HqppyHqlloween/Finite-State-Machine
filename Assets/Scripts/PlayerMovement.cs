using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Speed in m/s")]
    [SerializeField] private float m_speed = 6.0f;

    void Update()
    {
        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * m_speed;
        transform.position += velocity * Time.deltaTime;
        transform.LookAt(transform.position + velocity.normalized);
        Debug.DrawRay(transform.position, velocity, Color.red);
    }
}
