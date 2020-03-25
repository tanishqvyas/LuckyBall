using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

	public sound[] sounds;

	public static AudioManager instance;

    void Awake()
    {

    	if(instance == null)
    		instance = this;
    	else
    	{
    		Destroy(gameObject);
    		return;
    	}

    	DontDestroyOnLoad(gameObject);


    	foreach(sound s in sounds)
    	{
    		s.source = gameObject.AddComponent<AudioSource>();
    		s.source.name = s.name;
    		s.source.clip = s.clip;
    		s.source.loop = s.loop;
    		s.source.volume = s.volume;
    		s.source.pitch = s.pitch;	
    	}
        
    }


    void Start()
    {
    	Play("bgmusic");
    }

    public void Play(string name)
    {
    	sound s = Array.Find(sounds, sound => sound.name == name);
    
    	if(s == null)
    	{
    		Debug.Log("music ni mila");
    		return;
    	}

    	s.source.Play();

    }
}
