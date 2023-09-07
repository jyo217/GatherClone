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
        //�����ʵ��� �ؽ�Ʈ ���̰� 2~10 �̳���� ��ư Ȱ��ȭ �� ��ư �ؽ�Ʈ ��ȯ
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

        //���� ������ �۵��� ĳ���� ��Ʈ�ѷ��� �̸� ���� �޼ҵ� ȣ��, ���� �� ����
        SceneManager.LoadScene("MainScene");
        characterController.Rename(nameField.text);
    }

}