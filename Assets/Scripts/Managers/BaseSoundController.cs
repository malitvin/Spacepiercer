using UnityEngine;
using System.Collections;

namespace SpacePiercer.Managers
{
    [AddComponentMenu("Base/Sound Controller")]

    public class SoundObject
    {
        public AudioSource source;
        public GameObject sourceGO;
        public Transform sourceTR;
        public AudioClip clip;
        public string name;

        public SoundObject(AudioClip aClip, string aName, float aVolume)
        {
            /*in this (the constructor) we create a new audio source and store the details of the sound itself*/
            sourceGO = new GameObject("AudioSource_" + aName);
            sourceGO.transform.SetParent(GameObject.FindGameObjectWithTag("AudioManager").transform);
            sourceTR = sourceGO.transform;
            source = sourceGO.AddComponent<AudioSource>();
            source.name = "AudioSource_" + aName;
            source.playOnAwake = false;
            source.spatialBlend = 0.0f;
            source.clip = aClip;
            source.volume = aVolume;
            clip = aClip;
            name = aName;
        }

        public void PlaySound(Vector3 atPosition)
        {
            sourceTR.position = atPosition;
            source.PlayOneShot(clip);
        }
    }

    public class BaseSoundController : MonoBehaviour
    {
        public AudioClip[] GameplaySounds;
        public AudioClip[] UISounds;
        private int totalSounds;
        private ArrayList gameplayObjectList;
        private ArrayList uiObjectList;
        private SoundObject tempSoundObj;
        public float volume = 1;

        void Start()
        {
            gameplayObjectList = new ArrayList();
            uiObjectList = new ArrayList();

            // make sound objects for all of the sounds in (Gameplay)GameSounds array
            foreach (AudioClip theSound in GameplaySounds)
            {
                tempSoundObj = new SoundObject(theSound, theSound.name, volume);
                gameplayObjectList.Add(tempSoundObj);
                totalSounds++;
            }
            foreach (AudioClip theSound in UISounds)
            {
                tempSoundObj = new SoundObject(theSound, theSound.name, volume);
                uiObjectList.Add(tempSoundObj);
                totalSounds++;
            }
        }

        public void PlayGameplaySound(int anIndexNumber, Vector3 aPosition, float spacialBlend)
        {
            if (gameplayObjectList == null)
            {
                return;
            }
            // make sure we're not trying to play a sound indexed higher than exists in the array
            if (anIndexNumber > gameplayObjectList.Count)
            {
                anIndexNumber = gameplayObjectList.Count - 1;
            }

            tempSoundObj = (SoundObject)gameplayObjectList[anIndexNumber];
            tempSoundObj.source.spatialBlend = spacialBlend;
            tempSoundObj.PlaySound(aPosition);
        }

        public void PlayUISound(int anIndexNumber, Vector3 aPosition, float spacialBlend)
        {
            if (uiObjectList == null)
            {
                return;
            }
            // make sure we're not trying to play a sound indexed higher than exists in the array
            if (anIndexNumber > uiObjectList.Count)
            {
                anIndexNumber = uiObjectList.Count - 1;
            }

            tempSoundObj = (SoundObject)uiObjectList[anIndexNumber];
            tempSoundObj.source.spatialBlend = spacialBlend;
            tempSoundObj.PlaySound(aPosition);
        }
    }
}
