using UnityEngine;

public class Btn : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private SystemSoundsPool _systemSoundsPool;

    public void OnClick()
    {
        _systemSoundsPool.PlaySystemSound(_audioClip);
    }
}
