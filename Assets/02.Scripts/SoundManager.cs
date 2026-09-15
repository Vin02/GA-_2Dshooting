using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private AudioClip _bgmClip;
    [SerializeField] private AudioClip _bulletClip;
    [SerializeField] private AudioClip _explosionClip;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    private void Start()
    {
        if (_bgmClip == null) return;
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        _bgmSource.Play();
    }

    public void PlayBulletSound()
    {
        if (_bulletClip == null) return;
        _sfxSource.PlayOneShot(_bulletClip);
    }

    public void PlayExplosionSound()
    {
        if (_explosionClip == null) return;
        _sfxSource.PlayOneShot(_explosionClip);
    }
}
