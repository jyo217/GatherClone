using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneInputController : MonoBehaviour
{
    public static StartSceneInputController instance;
    private PlayerCharacterController characterController;
    private GameObject background;
    private InputField nameField;
    private Button startBtn;
    private Text startBtnText;
    private string InactiveMsg = "Start...?";
    private string ActiveMsg = "Start!!!";
    public string nameText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<PlayerCharacterController>();
        background = GameObject.Find("Background");
        nameField = GameObject.Find("NameField").GetComponent<InputField>();
        startBtn = GameObject.Find("StartBtn").GetComponent<Button>();
        startBtnText = GameObject.Find("StartBtnText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //네임필드의 텍스트 길이가 2~10 이내라면 버튼 활성화 및 버튼 텍스트 변환
        if (nameField.text.Length >= 2 && nameField.text.Length <= 10)
        {
            startBtn.interactable = true;
            startBtnText.text = ActiveMsg;
        }
        else
        {
            startBtn.interactable = false;
            startBtnText.text = InactiveMsg;
        }
    }
    
    public void OnClickButton()
    {
        Debug.Log($"Button Clicked, Player Name is {nameField.text}");
        SceneManager.LoadScene("MainScene");
    }

    public void SetActive(bool isTrue)
    {
        gameObject.SetActive(isTrue);
    }
}
