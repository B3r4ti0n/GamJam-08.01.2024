using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPanelScript : MonoBehaviour
{

    [SerializeField]
    private GameObject m_MonsterPrefab;

    [SerializeField]
    private Transform m_MonsterPosition;

    [SerializeField]
    private List<GameObject> m_MonsterPrefabList;
    // Start is called before the first frame update
    void Start()
    {
        if (m_MonsterPrefabList.Count > 0)
        {
            int rand = Random.Range(0, m_MonsterPrefabList.Count);

            GameObject randGameObject = m_MonsterPrefabList[rand];

            Instantiate(randGameObject, m_MonsterPosition.position, m_MonsterPosition.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("+1 pts");
        }
    }
}
