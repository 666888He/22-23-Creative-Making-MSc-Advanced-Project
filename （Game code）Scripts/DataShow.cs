using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataShow : MonoBehaviour
{
    public Image Hp;
    public Text Suipian;
    public Text Score;
    public GameObject End;

    public Button Restart;
    public Text EndSuipian;
    public Text EndScore;
    void Start()
    {
        Restart.onClick.AddListener(ReStart);
    }

    void ReStart() {

        SceneManager.LoadScene("Start");
    
    }

    // Update is called once per frame
    void Update()
    {
        Hp.fillAmount = GameManager.PlayerHP / 15f;
        Suipian.text = GameManager.SuiPian.ToString();
        Score.text = GameManager.Scoer.ToString();

    }

    public void ShowEnd() {
        EndSuipian.text = GameManager.SuiPian.ToString();
        EndScore.text = GameManager.Scoer.ToString();
        End.gameObject.SetActive(true);

    }

}
