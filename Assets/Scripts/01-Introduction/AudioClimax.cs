using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClimax : MonoBehaviour
{
    public AudioSource loopAudioSource;
    public AudioSource climaxAudioSource;
    public AudioSource goatAudioSource;

    bool climaxed;
    bool crossfading;
    bool loop;

    int transitionInterval = 200;

    void Start()
    {
        loopAudioSource.volume = 1.0f;
        climaxAudioSource.volume = 0.0f;
    }

    void Update()
    {
        if (!climaxed)
        {
            if (loopAudioSource.timeSamples >= loopAudioSource.clip.samples - 4000)
            {
                StartCoroutine(Crossfade(loopAudioSource, climaxAudioSource));
                StartCoroutine(PlayGoat());
                GetComponent<PictureClimax>().Climax();
            }

        }
        else if (!loop)
        {
            if (climaxAudioSource.timeSamples >= climaxAudioSource.clip.samples - 4000)
            {
                loop = true;
                StartCoroutine(Crossfade(climaxAudioSource, loopAudioSource));
            }
        }
    }

    IEnumerator Crossfade(AudioSource active, AudioSource inactive)
    {
        if (!crossfading)
        {
            crossfading = true;
            int samplesUntilChange = active.clip.samples - active.timeSamples;

            inactive.timeSamples = inactive.clip.samples - samplesUntilChange;

            while (inactive.volume < 1.0f)
            {
                active.volume -= (100.0f / (samplesUntilChange + transitionInterval));
                inactive.volume += (100.0f / (samplesUntilChange + transitionInterval));
                yield return new WaitForSeconds(0.001f);
            }

            yield return new WaitForSeconds(1.0f);
            climaxed = true;
            crossfading = false;
        }
        yield return null;
    }

    IEnumerator PlayGoat()
    {
        yield return new WaitForSeconds(1);
        goatAudioSource.Play();
    }
}
