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
        //��ȡ������������ӽ��ƶ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //��ȡ�����֣������ӽǷ���
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed,Space.World);
        transform.Translate(Vector3.forward * mouse * mouseSpeed);

    }
}
