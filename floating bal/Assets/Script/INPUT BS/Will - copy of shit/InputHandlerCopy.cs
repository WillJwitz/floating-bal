using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerCopy : MonoBehaviour
{
     Player Player;
    playerControl controlScript;
    GameObject playerObj;
    Vector2 input;

    private void Awake()
    {
        Player = new Player();
        playerObj = GameObject.Find("Player");
        
    }
    private void FixedUpdate()
    {
        input = Player.PlayerControls.WASD.ReadValue<Vector2>();
        print(input);

        playerObj.SendMessage("Move", input); 
    }
   private void OnEnable()
    {
        Player.PlayerControls.Enable();
    }
}
