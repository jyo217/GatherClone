using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneInputController : MonoBehaviour
{
    private PlayerCharacterController characterController;
    private InputField nameField;
    private Button startBtn;
    private Text startBtnText;
    private string InactiveMsg = "Start...?";
    private string ActiveMsg = "Start!!!";
    public string nameText;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<PlayerCharacterController>();
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
        DontDestroyOnLoad(nameField);

        //메인 씬에서 작동할 캐릭터 컨트롤러의 이름 변경 메소드 호출, 메인 씬 실행
        SceneManager.LoadScene("MainScene");
        characterController.Rename(nameField.text);
    }

}
