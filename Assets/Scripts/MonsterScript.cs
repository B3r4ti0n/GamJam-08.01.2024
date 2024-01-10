using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{

    [SerializeField]
    private GameObject m_RotatePoint;

    private bool _CanBeActivated;

    // Start is called before the first frame update
    void Start()
    {
        _CanBeActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_CanBeActivated)
        {
            if (collision.gameObject.CompareTag("Ammo"))
            {
                m_RotatePoint.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                _CanBeActivated = false;
                Settings.score++;
                Debug.Log("score : " + Settings.score + " pts.");
            }
        }
    }

    public void GetRotatePoint(GameObject rotatePoint)
    {
        m_RotatePoint = rotatePoint;
    }
}
