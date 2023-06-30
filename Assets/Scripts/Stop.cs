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
    private float time = 0f;

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
            Time.timeScale = time;
            time++;
            time = time % 2;
        }
    }

    public void Resume()
    {
        if(isShow != false)
        {
            isShow = !isShow;
            SettingPanel.gameObject.SetActive(isShow);
            Time.timeScale = time;
            time++;
            time = time % 2;
        }
    }
    //��ͣ�ͼ�����Ϸ
    public void ControlTime()
    {
        //��������
        if (!BtnState)
        {
            BtnState = false;
      
            Time.timeScale = 1f;
            isShow = !isShow;
            SettingPanel.gameObject.SetActive(isShow);
        }
        else
        {
            BtnState = true;
  
            //��ʱ������Ϊ0,�����ֹͣ�˶�,��������������Ϊ0.5f
            Time.timeScale = 0f;
        }
    }
}