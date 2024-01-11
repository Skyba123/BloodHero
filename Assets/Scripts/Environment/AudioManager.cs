using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [Header("Clips")]
    public AudioClip playerAttack;
    public AudioClip playerJump;
    public AudioClip playerTakeDamage;
    public AudioClip playerRun;
    public AudioClip enemyAttack;
    public AudioClip enemyTakeDamage;
    public AudioClip enemyRun;
}
