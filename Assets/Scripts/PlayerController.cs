using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    private bool _IsDown;

    [SerializeField]
    private Transform m_Canon;

    [SerializeField]
    private GameObject m_Bullet;

    [SerializeField]
    private GameObject m_RotatePoint;

    private float _fireRate = 0.5f;

    private float _lastBulletSpawn;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _IsDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Squat and Get Up
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!_IsDown)
            {
                // Start squat animation
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
            _IsDown = true;
        }
        else
        {
            if (_IsDown)
            {
                // Get up
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            _IsDown = false;
        }
        #endregion

        #region Mouse AIM

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        m_RotatePoint.transform.forward = ray.direction;

        #endregion

        #region Fire Call


        if (Input.GetKey(KeyCode.Mouse0))
        {
             Fire();
        }

        #endregion
    }

    private void Fire()
    {
        if (Time.time > _fireRate + _lastBulletSpawn)
        {
            GameObject instance = Instantiate(m_Bullet, m_Canon.position, m_Canon.rotation);

            Rigidbody rigBod = instance.GetComponent<Rigidbody>();

            rigBod.AddForce(m_Canon.forward * 500, ForceMode.Impulse);

            Destroy(instance, 1);

            _lastBulletSpawn = Time.time;
        }
    }
}
