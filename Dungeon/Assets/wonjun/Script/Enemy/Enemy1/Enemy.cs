using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool follow;
    SpriteRenderer sp;
    public GameObject target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;


    private void Start()
    {
        follow = true;
        sp = GetComponent<SpriteRenderer>();    
    }
    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            MoveToTarget();
        }
    }

    public void MoveToTarget()
    {
        // Player�� ���� ��ġ�� �޾ƿ��� Object
        target = GameObject.Find("Player");
        // Player�� ��ġ�� �� ��ü�� ��ġ�� ���� ���� ����ȭ �Ѵ�.
        direction = (target.transform.position - transform.position).normalized;
        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = 0.008f;
        // Player�� ��ü ���� �Ÿ� ���
        float distance = Vector3.Distance(target.transform.position, transform.position);
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