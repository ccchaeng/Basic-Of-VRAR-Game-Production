using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject quiz1;
    public GameObject quiz2;
    public GameObject quiz3;
    public GameObject quiz4;
    public GameObject quiz5;

    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        quiz1.SetActive(false);
        quiz2.SetActive(false);
        quiz3.SetActive(false);
        quiz4.SetActive(false);
        quiz5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0))
        {
            //Ray�� �߻��Ͽ� Ŭ���� ��ġ�� �ִ� ������Ʈ�� ã��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray�� ������Ʈ�� �浹���� ��
            if(Physics.Raycast(ray, out hit))
            {
                //�浹�� ������Ʈ�� Apple�̶��
                if (hit.collider.gameObject.CompareTag("Apple"))
                {
                    //Quiz1 �̹����� Ȱ��ȭ
                    quiz1.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Banana"))
                {
                    quiz2.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Steak"))
                {
                    quiz3.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Avocado"))
                {
                    quiz4.SetActive(true);
                }
                else if (hit.collider.gameObject.CompareTag("Carrot"))
                {
                    quiz5.SetActive(true);
                }
            }
        }
    }

    public void Answer1()
    {
        count++;
        quiz1.SetActive(false);
    }

    public void Answer2()
    {
        count++;
        quiz2.SetActive(false);
    }

    public void Answer3()
    {
        count++;
        quiz3.SetActive(false);
    }

    public void Answer4()
    {
        count++;
        quiz4.SetActive(false);
    }

    public void Answer5()
    {
        count++;
        quiz5.SetActive(false);
    }

    public void Wrong()
    {
        HPManager.hp -= 1;
        if(HPManager.hp <= 0 )
        {
            GameManager.Instance.Die();
        }
    }

}
