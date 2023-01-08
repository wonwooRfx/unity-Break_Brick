using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBricks : MonoBehaviour
{
    int count; // 횟수
    int maxCount = 2; // 최대횟수
 

    private void OnCollisionEnter(Collision collision)
    {
        // 부딫히는 물체의 태그가 Ball이면 카운트가 1씩 추가되고 2가 되면 자신을 삭제하라
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
