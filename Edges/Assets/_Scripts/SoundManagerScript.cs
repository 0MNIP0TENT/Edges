using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static SoundManagerScript instance = null;
    public static SoundManagerScript Instance()
    {
         return instance; 
    }

    public static AudioClip fall;
    public static AudioClip jump;
    public static AudioClip _throw;
    public static AudioClip powerUp;
    public static AudioClip[] playList;
    static AudioSource[] source;
    
    int numberOfSongs = 7;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        // soundfx
        fall = Resources.Load<AudioClip>("Fall");
        jump = Resources.Load<AudioClip>("Jump");
        _throw = Resources.Load<AudioClip>("Throw");
        powerUp = Resources.Load<AudioClip>("PowerUp");
        // background music
        playList = new AudioClip[numberOfSongs];
        playList[0] = Resources.Load<AudioClip>("Dbz");
        playList[1] = Resources.Load<AudioClip>("Numb");
        playList[2] = Resources.Load<AudioClip>("EpicBattle");
        playList[3] = Resources.Load<AudioClip>("Bad");
        playList[4] = Resources.Load<AudioClip>("Confrontment");
        playList[5] = Resources.Load<AudioClip>("TheRaisingFightingSpirit");
        playList[6] = Resources.Load<AudioClip>("ImNauruto");

        source = GetComponents<AudioSource>();

        
        
    }

    // Use this for initialization
    void Start () {
       
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
    public static void PlaySong()
    {
        int randomSong = Random.Range(0,playList.Length);
        source[4].clip = playList[randomSong];
        source[4].Play();
    }

    public static void StopMusic()
    {
        source[4].Stop();
    }

    public static void CheckMusic()
    {
        if(source[4].isPlaying == false)
        {
            PlaySong();
        }
       
    }
    public static bool isplaying()
    {
        if (source[4].isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
} 
