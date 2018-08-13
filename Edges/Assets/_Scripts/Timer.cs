using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class Timer : MonoBehaviour
{
    public static int timeLeft = 3;
    public Text countDownText;
 
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }
 
    // Update is called once per frame
    void Update()
    {
        countDownText.text = ("Get Ready! = " + timeLeft);
 
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