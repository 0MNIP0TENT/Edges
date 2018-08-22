using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip fall;
    public static AudioClip jump;
    public static AudioClip _throw;
    public static AudioClip powerUp;
    static AudioSource[] source;

	// Use this for initialization
	void Start () {
        fall = Resources.Load<AudioClip>("Fall");
        jump = Resources.Load<AudioClip>("Jump");
        _throw = Resources.Load<AudioClip>("Throw");
        powerUp = Resources.Load<AudioClip>("PowerUp");
        source = GetComponents<AudioSource>();

      // DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fall":
                source[0].PlayOneShot(fall,1f); 
                break;
            case "Jump":
                source[1].PlayOneShot(jump, 1f);
                break;
            case "Throw":
                source[2].PlayOneShot(_throw, 1f);
                break;
            case "PowerUp":
                source[3].PlayOneShot(powerUp, 1f);
                break;
        }
    }
}
