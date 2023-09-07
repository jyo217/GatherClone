using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterController : MonoBehaviour
{
    public static string playerName;
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAimEvent;
    public event Action<string> OnRenameEvent;

    private Text nameText;

    private void Start()
    {
        nameText = GameObject.Find("NameUI").GetComponent<Text>();    
    }

    private void Update()
    {
        
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAimEvent(Vector2 direction)
    {
        OnAimEvent?.Invoke(direction);
    }

    public void Rename(string name)
    {
        nameText.text = name;
    }
}
