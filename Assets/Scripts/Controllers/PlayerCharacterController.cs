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
    private StartSceneInputController startSceneInputController;
    private bool startSceneisActive = true;
    private void Start()
    {
        startSceneInputController = StartSceneInputController.instance;
        nameText = GameObject.Find("NameUI").GetComponent<Text>();
        nameText.text = GameObject.Find("NameField").GetComponent<InputField>().text;
    }

    private void Update()
    {
        if (startSceneisActive)
        {
            startSceneInputController.gameObject.SetActive(false);
            startSceneisActive = false;
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAimEvent(Vector2 direction)
    {
        OnAimEvent?.Invoke(direction);
    }
}
