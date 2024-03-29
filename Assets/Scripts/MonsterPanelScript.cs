using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPanelScript : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform m_MonsterPosition;

    [SerializeField]
    private GameObject m_MonsterPositionGameObject;

    [SerializeField]
    private List<GameObject> m_MonsterPrefabList;

    [SerializeField]
    private GameObject m_RotatePoint;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (m_MonsterPrefabList.Count > 0)
        {
            int rand = Random.Range(0, m_MonsterPrefabList.Count);

            GameObject randGameObject = m_MonsterPrefabList[rand];

            var monster = Instantiate(randGameObject, m_MonsterPosition.position, randGameObject.transform.rotation);

            MonsterScript.m_RotatePoint = m_RotatePoint;

            monster.transform.parent = m_MonsterPositionGameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
