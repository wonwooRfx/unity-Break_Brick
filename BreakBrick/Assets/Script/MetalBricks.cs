using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBricks : MonoBehaviour
{
    int count; // Ƚ��
    int maxCount = 2; // �ִ�Ƚ��
 

    private void OnCollisionEnter(Collision collision)
    {
        // �΋H���� ��ü�� �±װ� Ball�̸� ī��Ʈ�� 1�� �߰��ǰ� 2�� �Ǹ� �ڽ��� �����϶�
        if(collision.gameObject.tag == "Ball")
        {
            count++;
            if(count >= maxCount)
            {
                Destroy(gameObject);
            }
        }
    }
}
