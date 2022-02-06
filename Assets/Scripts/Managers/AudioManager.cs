using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource BackGroundAudioSource;

    [SerializeField]
    private AudioClip BackGroundMainMenu, BackGroundGame;
    [SerializeField]
    private AudioClip walk, chest_open, key_take, game_end, click;

    private float walkDelay=0.3f;
    private float walkLastPlayed;

    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        BackGroundAudioSource=GetComponent<AudioSource>();
        BackGroundMainMenuPlay();
    }
    public void BackGroundMainMenuPlay()
    {
        BackGroundAudioSource.clip=BackGroundMainMenu;
        BackGroundAudioSource.Play();
    }
    public void BackGroundGamePlay()
    {
        BackGroundAudioSource.clip=BackGroundGame;
        BackGroundAudioSource.Play();
    }
    public void PlayWalk()
    {
        if(Time.time-walkLastPlayed>walkDelay)
        {
            walkLastPlayed=Time.time;
            PlayClip(walk);
        }
    }
    public void PlayChestOpen()
    {
        PlayClip(chest_open);
    }
    public void PlayKeyTake()
    {
        PlayClip(key_take);
    }
    public void PlayGameEnd()
    {
        PlayClip(game_end);
    }
    public void PlayClick()
    {
        PlayClip(click);
    }
    private void PlayClip(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip=clip;
        audioSource.Play();
        StartCoroutine(DelayDestroyer(audioSource,clip.length));
    }
    private IEnumerator DelayDestroyer(Object toDestroy,float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(toDestroy);
    }
}
