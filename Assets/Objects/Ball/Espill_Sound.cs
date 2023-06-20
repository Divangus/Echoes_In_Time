using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espill_Sound : MonoBehaviour
{
    public AudioClip[] _SaxophoneClips;
    public AudioClip[] _PianoClips;
    public AudioClip[] _DrumsClips;
    public int _instrument_name;
    int _saxoCount;
    int _pianoCount;
    int _drumsCount;
    // Start is called before the first frame update
    void Start()
    {
        _saxoCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playBoundSounds()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        switch (_instrument_name)
        {
            case 0:
                audioSource.PlayOneShot(_SaxophoneClips[_saxoCount]);
                _saxoCount++;
                break;
            case 1:
               audioSource.PlayOneShot(_PianoClips[_pianoCount]);
               _pianoCount++;
               break;
          //  case "drums":
          //      audioSource.PlayOneShot(_DrumsClips[_drumsCount]);
          //      _drumsCount++;
          //      break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Espill")) playBoundSounds();
    }
}
