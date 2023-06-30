using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLives : MonoBehaviour
{
    public int maxLives = 5; // 关卡最大生命值
    public int currentLives; // 当前生命值
    private int loss = 1;
    public TextMeshProUGUI livesText;
    public Animator livesAnimator;
    

    private void Start()
    {
        currentLives = maxLives; // 在开始时将当前生命值设置为最大生命值
    }

    // 减少生命值的方法
    public void DecreaseLives()
    {
        currentLives -= loss;
        UpdateLivesText();
        livesAnimator.SetTrigger("loss");

        if (currentLives <= 0)
        {
            // 关卡失败的逻辑
            GameOver();
        }
    }
    private void UpdateLivesText()
    {
        livesText.text = "Health:" + currentLives.ToString(); // 将整数转换为字符串
    }

    // 游戏结束的方法
    private void GameOver()
    {
        SceneManager.LoadScene(4);
        // 在这里实现游戏失败的逻辑，例如重新加载场景或显示失败界面等
    }
}

