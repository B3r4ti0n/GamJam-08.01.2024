using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public static GameObject m_RotatePoint;

    private bool _CanBeActivated;

    [SerializeField]
    private AudioSource m_AudioSource;

    [SerializeField]
    private AudioClip m_MonsterAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("RepeatAudioClip", 0f, 8f);
        _CanBeActivated = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RepeatAudioClip()
    {
        m_AudioSource.clip = m_MonsterAudioSource;
        m_AudioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_CanBeActivated)
        {
            if (collision.gameObject.CompareTag("Ammo"))
            {
                m_RotatePoint.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                _CanBeActivated = false;
                Settings.score++;
                Debug.Log("score : " + Settings.score + " pts.");
            }
        }
    }

}
