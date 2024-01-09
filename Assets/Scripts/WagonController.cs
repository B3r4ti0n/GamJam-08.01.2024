using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameObject m_RotateRightPoint;
    [SerializeField]
    private GameObject m_RotateLeftPoint;

    private bool _IsCentered;
    private bool _IsFallOverLeft;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _IsCentered = true;
    }

    // Update is called once per frame
    void Update()
    {
        #region Switch to the sides
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Switch to the left side
            if (_IsCentered)
            {
                m_RotateLeftPoint.transform.Rotate(0.0f, 0.0f, 20.0f, Space.Self);
                _IsCentered = false;
                _IsFallOverLeft = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Switch to the right side
            if (_IsCentered)
            {
                m_RotateRightPoint.transform.Rotate(0.0f, 0.0f, -20.0f, Space.Self);
                _IsFallOverLeft = false;
                _IsCentered = false;
            }
        }
        else
        {
            // Back to center
            if (!_IsCentered)
            {
                if (!_IsFallOverLeft)
                {
                    m_RotateRightPoint.transform.Rotate(0.0f, 0.0f, 20.0f, Space.Self);
                } else
                {
                    m_RotateLeftPoint.transform.Rotate(0.0f, 0.0f, -20.0f, Space.Self);
                }
            }
            _IsCentered = true;

        }
        #endregion

    }
}
