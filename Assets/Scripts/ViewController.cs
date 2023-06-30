using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    public float speed = 30;
    public float mouseSpeed = 400;
    // Update is called once per frame
    void Update()
    {
        //获取方向键，控制视角移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //获取鼠标滚轮，控制视角放缩
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed,Space.World);
        transform.Translate(Vector3.forward * mouse * mouseSpeed);

    }
}
