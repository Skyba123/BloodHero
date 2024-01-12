using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingAudio : MonoBehaviour
{

    [SerializeField] GameObject PrefabAudio;
    [SerializeField] Transform Point;
    [SerializeField] AudioClip[] _AudioClip;
    [SerializeField] int time, Movetime;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (time != 0) return;
            Instantiate(PrefabAudio,Point);
            int I = Random.Range(0, _AudioClip.Length - 1);
            time = Movetime;
            GameObject _temp = Instantiate(PrefabAudio, Point);
            _temp.GetComponent<AudioSource>().clip = _AudioClip[I];
            _temp.GetComponent<AudioSource>().Play();
            Destroy( _temp,1 );
        }
        
    }
    private void FixedUpdate()
    {
        if (time > 0)
        {
            time--;
        }
    }
}
