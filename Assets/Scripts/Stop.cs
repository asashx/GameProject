using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSitting : MonoBehaviour
{
    public GameObject SettingPanel;     //设置面板
    public bool isShow;                 //是否显示
    public GameObject ControlButton;    //暂停/继续游戏的按钮
    public bool BtnState = false;       //暂停游戏按钮的状态

    void Start()
    {
        //寻找组件,注册点击事件
        ControlButton.GetComponent<Button>().onClick.AddListener(ControlTime);

    }

    void Update()
    {
        SettingMenu();
    }

    //设置面板
    public void SettingMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShow = !isShow;
            SettingPanel.gameObject.SetActive(isShow);
        }
    }
    //暂停和继续游戏
    public void ControlTime()
    {
        //如果点击了
        if (BtnState)
        {
            BtnState = false;
      
            //将时间设置为0,画面会停止运动,慢动作可以设置为0.5f
            Time.timeScale = 1f;
        }
        else
        {
            BtnState = true;
  
            //将时间设置为0,画面会停止运动,慢动作可以设置为0.5f
            Time.timeScale = 0f;
        }
    }
}