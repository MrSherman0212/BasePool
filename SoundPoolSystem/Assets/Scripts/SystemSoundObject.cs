using System.Collections;
using UnityEngine.Pool;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SystemSoundObject : MonoBehaviour, IPoolable
{
    private AudioSource _audioSource;
    private float _lifetime;
    private ObjectPool<SystemSoundObject> _soundsPool;

    public void Init(ObjectPool<SystemSoundObject> soundsPool)
    {
        _soundsPool = soundsPool;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null)
        {
            _soundsPool.Release(this);
            return;
        }
        _lifetime = audioClip.length;
        _audioSource.clip = audioClip;
        _audioSource.Play();
        StartCoroutine(DeactivateSound());
    }

    private IEnumerator DeactivateSound()
    {
        yield return new WaitForSeconds(_lifetime);
        _soundsPool.Release(this);
    }
}
