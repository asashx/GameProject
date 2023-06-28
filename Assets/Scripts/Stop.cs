using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSitting : MonoBehaviour
{
    public GameObject SettingPanel;     //�������
    public bool isShow;                 //�Ƿ���ʾ
    public GameObject ControlButton;    //��ͣ/������Ϸ�İ�ť
    public bool BtnState = false;       //��ͣ��Ϸ��ť��״̬

    void Start()
    {
        //Ѱ�����,ע�����¼�
        ControlButton.GetComponent<Button>().onClick.AddListener(ControlTime);

    }

    void Update()
    {
        SettingMenu();
    }

    //�������
    public void SettingMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShow = !isShow;
            SettingPanel.gameObject.SetActive(isShow);
        }
    }
    //��ͣ�ͼ�����Ϸ
    public void ControlTime()
    {
        //��������
        if (BtnState)
        {
            BtnState = false;
      
            //��ʱ������Ϊ0,�����ֹͣ�˶�,��������������Ϊ0.5f
            Time.timeScale = 1f;
        }
        else
        {
            BtnState = true;
  
            //��ʱ������Ϊ0,�����ֹͣ�˶�,��������������Ϊ0.5f
            Time.timeScale = 0f;
        }
    }
}