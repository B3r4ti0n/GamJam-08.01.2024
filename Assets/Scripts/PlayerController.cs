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

    private float _FireRate;

    private float _LastBulletSpawn;

    [SerializeField]
    private int _Ammunition;

    [SerializeField]
    private Animator m_Animator;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _IsDown = false;
        _FireRate = 0.5f;
        _Ammunition = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Settings._isAlive)
        {

        #region Squat and Get Up
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!_IsDown)
            {
                // Start squat animation
                m_Animator.SetBool("IsCrouching", true);
            }
            _IsDown = true;
        }
        else
        {
                Debug.Log("test");
            if (_IsDown)
            {
                // Get up
                m_Animator.SetBool("IsCrouching", false);
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
            if (_Ammunition > 0)
            {
                Fire();
            }
        }

        #endregion
        }

    }

    private void Fire()
    {
        if (Time.time > _FireRate + _LastBulletSpawn)
        {
            // Fire animation
            GameObject instance = Instantiate(m_Bullet, m_Canon.position, m_Canon.rotation);

            Rigidbody rigBod = instance.GetComponent<Rigidbody>();

            rigBod.AddForce(m_Canon.forward * 500, ForceMode.Impulse);

            Destroy(instance, 1);

            _LastBulletSpawn = Time.time;

            _Ammunition--;
            // Play animation ammunition bar decreasing
        }
    }

    public void Reload()
    {
        if (_Ammunition <= 15)
        {
            // Play animation ammunition bar increasing
            _Ammunition += 5;
        } else
        {
            _Ammunition = 20;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Settings._isAlive = false;

            // Show Game Over Canvas 
        }
    }
}
