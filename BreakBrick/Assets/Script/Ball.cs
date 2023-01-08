using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    float radian = 180f;
    Rigidbody rid;
    public float speed; // 속도
    int point = 0; // 점수
    public Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        scoreTxt.text = "점수: " + point.ToString();

        if (point >= 1750) // 1750과 같거나 크면 Win 씬으로 전환
        {
            SceneManager.LoadScene("Win");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePos = rid.position + transform.up * speed * Time.deltaTime;
        rid.MovePosition(movePos); // 물리법칙을 적용받지 않고 강제로 움직이게 하는 메서드
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UpWall") // 위 벽이라면
        {
            Vector3 top = transform.eulerAngles;
            top.z = radian - top.z;
            transform.eulerAngles = top;
        }
        if (collision.gameObject.tag == "Wall") // 양 옆의 벽이라면
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
            Destroy(collision.gameObject); // 부딫힌 물체 삭제
            point += 50; // 부딫히면 50점 추가
        }
        if (collision.gameObject.tag == "MetalBrick")
        {
            Vector3 top = transform.eulerAngles;
            top.z = radian - top.z;
            transform.eulerAngles = top;
            point += 50; // 부딫히면 50점 추가

        }
        if(collision.gameObject.tag == "DownWall")
        {
            SceneManager.LoadScene("Fail"); //패배씬으로 이동
        }
       
    }
}
