using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class Timer : MonoBehaviour
{
    //public static Timer instance = null;
    //public static Timer Instance()
    //{
    //    return instance;
    //}

    public static int timeLeft = 3;
    public Text countDownText;

    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Use this for initialization
    void Start()
    {
       // countDownText = GameObject.Find("Canvas").GetComponent<Text>();
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance().levelChanged == true)
        {
            StartCoroutine("LoseTime");
         //   LevelManager.Instance().levelChanged = false;
        }
        //countDownText.text = ("Get Ready! = " + timeLeft);
        countDownText.text = ("Get Ready!");

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countDownText.text = "GO!";
        }
    }
 
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
       


    }
}