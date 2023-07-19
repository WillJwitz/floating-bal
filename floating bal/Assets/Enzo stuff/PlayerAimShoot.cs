using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimShoot : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private Vector2 worldPos;
    private Vector2 direction;

    private void Update()
    {
        HandleGunRotation(); 
    }

    private void HandleGunRotation()
    {
        //rotate the gun to the mouse
        worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPos - (Vector2)weapon.transform.position).normalized;
        weapon.transform.right = direction;
    }
}
