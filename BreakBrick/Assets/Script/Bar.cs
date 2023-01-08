using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float moveSpeed; // 움직일 속도

    Rigidbody rid;

    float[] angles = { -60, -45, 0, 45, 60 };
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 좌우 키보드 입력
        h = h * moveSpeed * Time.deltaTime; // 이동 거리 보정

        transform.Translate(Vector3.right * h); // 실제 이동

        if(transform.position.x >= 3f) // x 좌표가 3f보다 크다면
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z); // 3f에 고정
        }

        if (transform.position.x <= -2.7f) // x좌표가 -2.7f보다 작다면
        {
            transform.position = new Vector3(-2.7f, transform.position.y, transform.position.z); // -3f에 고정
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //태그가 Ball이라면 랜덤한 각도로 반사
        if (collision.gameObject.tag == "Ball")
        {
            int randomAngle = Random.Range(0, angles.Length);
            Vector3 bar = collision.transform.eulerAngles;
            bar.z = angles[randomAngle];
            collision.transform.eulerAngles = bar;
        }
    }
}
