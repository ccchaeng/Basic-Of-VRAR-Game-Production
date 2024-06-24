using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    GameObject timeText;
    GameObject remainText;
    public GameObject exitMassage;
    public GameObject clear;
    public Text bestT;

    float playTime;
    float time = 60.0f;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playTime = 0;
        this.timeText = GameObject.Find("Time");
        this.remainText = GameObject.Find("remain");
        isGameOver = false;

        //exitMassage.SetActive(false);

        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        this.time -= Time.deltaTime;
        this.timeText.GetComponent<Text>().text = this.time.ToString("F1");

        this.remainText.GetComponent<Text>().text = "���� ���� : " + (5 - QuizController.count);


        if (time <= 0.0f && !isGameOver) Die();
        if (QuizController.count == 5 && !isGameOver) Clear();
    }
    

    //��� �������� �� ã���� ���
    public void Clear()
    {
        isGameOver = true;
        clear.SetActive(true);
        BestTime();
    }

    //������ ���� ã�� �ְ� ���
    public void BestTime()
    {
        float BestTime = PlayerPrefs.GetFloat("bestTime", playTime);
        if(BestTime > playTime)
        {
            BestTime = playTime;
            PlayerPrefs.SetFloat("bestTime", BestTime);
        }
        bestT.text = "�ְ� ��� : " + (int)BestTime;
    }

    //���� �����
    public void Restart()
    {
        Debug.Log("Restart button clicked");
        SceneManager.LoadScene("GameScene");

    }

    //��Ʈ�� �� ��Ƽ� �׾��� ��
    public void Die()
    {
        Debug.Log("Die() method is called");
        isGameOver = true;
        exitMassage.SetActive(true);
    }

    //���� ����
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}