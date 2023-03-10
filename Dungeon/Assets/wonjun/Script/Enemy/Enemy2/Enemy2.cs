using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public bool follow2;
    SpriteRenderer sp;
    public GameObject target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    public GameObject bullet;
    public float spawnTime = 3f;
    float enemydie = 0f;

    private void Start()
    {
        follow2 = true;
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(follow2 == true)
        {
            MoveToTarget();
        }
        if (enemydie == 3){
            Destroy(gameObject);
        }
    }

    public void MoveToTarget()
    {
        // Player의 현재 위치를 받아오는 Object
        target = GameObject.Find("Player");
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.transform.position - transform.position).normalized;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        velocity = 0.008f;
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (distance <= 10.0f)
        {
            if (spawnTime > 3)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                spawnTime = 0f;
                enemydie++;
            }

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z);
        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            velocity = 0.0f;
        }

        if (direction.x < 0)
        {
            sp.flipX = false;
        }
        else if (direction.x > 0)
        {
            sp.flipX = true;
        }
    }
}
