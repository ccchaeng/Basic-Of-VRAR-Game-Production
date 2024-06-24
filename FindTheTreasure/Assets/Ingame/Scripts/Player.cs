using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;

    public float speed = 10.0f;
    public float rotateSpeed = 10.0f;

    public Transform PlayerTr; //�̵��ϴ� ����� ��Ÿ���� ����
    Animator anim; //Animator ����

    // Start is called before the first frame update
    void Start()
    {
        PlayerTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        float h = joy.Horizontal;
        float v = joy.Vertical;


        Vector3 dir = new Vector3(h, 0, v);
        if(!(h == 0 && v == 0))
        {
            //�̵��� ȸ���� �Բ� ó��
            transform.position += dir * speed * Time.deltaTime;
            //ȸ���ϴ� �κ�
            //���� ȸ����(transform.rotation)���� �ٶ󺸴� ����(Quaternion.LookRotation(dir))���� ������ ȸ���ӵ��� ȸ����
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }

        if(v >= 0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(v <= -0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(h >= 0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else if(h <= -0.1f)
        {
            anim.SetBool("IsWalk", true);
            anim.SetBool("IsSit", false);
        }
        else
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsSit", true);
        }
    }
}
