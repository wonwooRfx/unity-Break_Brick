using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float moveSpeed; // ������ �ӵ�

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
        float h = Input.GetAxis("Horizontal"); // �¿� Ű���� �Է�
        h = h * moveSpeed * Time.deltaTime; // �̵� �Ÿ� ����

        transform.Translate(Vector3.right * h); // ���� �̵�

        if(transform.position.x >= 3f) // x ��ǥ�� 3f���� ũ�ٸ�
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z); // 3f�� ����
        }

        if (transform.position.x <= -2.7f) // x��ǥ�� -2.7f���� �۴ٸ�
        {
            transform.position = new Vector3(-2.7f, transform.position.y, transform.position.z); // -3f�� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�±װ� Ball�̶�� ������ ������ �ݻ�
        if (collision.gameObject.tag == "Ball")
        {
            int randomAngle = Random.Range(0, angles.Length);
            Vector3 bar = collision.transform.eulerAngles;
            bar.z = angles[randomAngle];
            collision.transform.eulerAngles = bar;
        }
    }
}
