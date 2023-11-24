using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{
    public GameObject ob;
    public GameObject btn;
    public Image process;
    public Button Btn_Start;
    // Start is called before the first frame update
    void Start()
    {
        //ob.SetActive(false);
        //Btn_Start.onClick.AddListener(Load);
    }
    void Load() {
        //btn.gameObject.SetActive(false);
        //ob.SetActive(true);
        
        //StartCoroutine(LoadSceneAsync());

    }
    IEnumerator LoadSceneAsync() {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); 
                                                                                                              
        while (!operation.isDone)   //当场景没有加载完毕
        {
            process.fillAmount = operation.progress;  //进度条与场景加载进度对应
            Debug.Log("加载进度"+ operation.progress);
            yield return null;
        }
    }


    public void MyStartGoScene()
    {
        btn.SetActive(false);
        ob.SetActive(true);
        StartCoroutine(YanShi());
    }

    IEnumerator YanShi()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
