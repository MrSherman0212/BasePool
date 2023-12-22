using UnityEngine;

public class SystemSoundsPool : BasePool<SystemSoundObject>
{
    [SerializeField] private SystemSoundObject _soundObjectPrefab;

    protected override SystemSoundObject CreatePoolObj()
    {
        SystemSoundObject soundObject = Instantiate(_soundObjectPrefab, transform);
        soundObject.Init(_pool);
        return soundObject;
    }

    public void PlaySystemSound(AudioClip audioClip)
    {
        if (audioClip == null) return;
        _pool.Get().PlaySound(audioClip);
    }
}
