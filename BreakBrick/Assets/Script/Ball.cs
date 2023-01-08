using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    float radian = 180f;
    Rigidbody rid;
    public float speed; // �ӵ�
    int point = 0; // ����
    public Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        scoreTxt.text = "����: " + point.ToString();

        if (point >= 1750) // 1750�� ���ų� ũ�� Win ������ ��ȯ
        {
            SceneManager.LoadScene("Win");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePos = rid.position + transform.up * speed * Time.deltaTime;
        rid.MovePosition(movePos); // ������Ģ�� ������� �ʰ� ������ �����̰� �ϴ� �޼���
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UpWall") // �� ���̶��
        {
            Vector3 top = transform.eulerAngles;
            top.z = radian - top.z;
            transform.eulerAngles = top;
        }
        if (collision.gameObject.tag == "Wall") // �� ���� ���̶��
        {
            Vector3 side = transform.eulerAngles;
            side.z = (radian * 2) - side.z;
            transform.eulerAngles = side;
        }
        if(collision.gameObject.tag == "Brick")
        {
            Vector3 top = transform.eulerAngles;
            top.z = radian - top.z;
            transform.eulerAngles = top;
            Destroy(collision.gameObject); // �΋H�� ��ü ����
            point += 50; // �΋H���� 50�� �߰�
        }
        if (collision.gameObject.tag == "MetalBrick")
        {
            Vector3 top = transform.eulerAngles;
            top.z = radian - top.z;
            transform.eulerAngles = top;
            point += 50; // �΋H���� 50�� �߰�

        }
        if(collision.gameObject.tag == "DownWall")
        {
            SceneManager.LoadScene("Fail"); //�й������ �̵�
        }
       
    }
}
