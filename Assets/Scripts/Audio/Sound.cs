using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private SoundObject _soundObject;
    [SerializeField] private bool _playOnAwake = false;
    private AudioSource _source;

    private void Awake()
    {
        _source = gameObject.AddComponent<AudioSource>();
        _source.clip = _soundObject.clip;
        _source.outputAudioMixerGroup = _soundObject.mixerGroup ?? AudioMixerVolume.Instance.MixerGroup;
        _source.loop = _soundObject.loop;
        _source.playOnAwake = _playOnAwake;
        _source.spatialBlend = _soundObject.is3d ? 1f : 0f;
        _source.volume = _soundObject.volume;
        _source.pitch = _soundObject.pitch;
    }

    private void Start()
    {
        if (_source.playOnAwake)
            Play();
    }

    public void Play()
    {
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }
}
