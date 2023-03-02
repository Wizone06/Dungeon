using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sp;
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;


    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();    
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        // Player�� ���� ��ġ�� �޾ƿ��� Object
        target = GameObject.Find("Player").transform;
        // Player�� ��ġ�� �� ��ü�� ��ġ�� ���� ���� ����ȭ �Ѵ�.
        direction = (target.position - transform.position).normalized;
        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = 0.01f;
        // Player�� ��ü ���� �Ÿ� ���
        float distance = Vector3.Distance(target.position, transform.position);
        // �����Ÿ� �ȿ� ���� ��, �ش� �������� ����
        if (distance <= 10.0f)
        {
            

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z);
        }
        // �����Ÿ� �ۿ� ���� ��, �ӵ� �ʱ�ȭ 
        else
        {
            velocity = 0.0f;
        }

        if(direction.x < 0)
        {
            sp.flipX = false;
        }
        else if( direction.x > 0)
        {
            sp.flipX = true;
        }
    }
}