using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public float speed = Settings.speed_block;
    [SerializeField] 
    private GameObject railPrefab;
    [SerializeField] 
    private GameObject target;
    [SerializeField] 
    private GameObject trigger;
    [SerializeField]
    private List<GameObject> list_tunnel;
    [SerializeField] 
    private  List<GameObject> list_rail;
    private GameObject tunnelPrefab;
    [SerializeField] 
    private GameObject EnemySign;
    [SerializeField] 
    private GameObject RocSign;
    void Start()
    {
        tunnelPrefab = list_tunnel[Random.Range(0, list_tunnel.Count)];
        GameObject tunnel = Instantiate(tunnelPrefab, Vector3.zero, Quaternion.identity, transform);
        tunnel.transform.localPosition = new Vector3(0f, -0.5f, 0f);
        tunnel.transform.localScale = new Vector3(1f, 1f, 0.7f);

        int random = Random.Range(0, 100);
        if(transform.position.z > -45){
            random = 0;
        }
        switch (random)
        {
            case >95:
                random = 1;
                break;
            default:
                random = 0;
                break;
        }

        railPrefab = list_rail[random];
        GameObject rail = Instantiate(railPrefab, Vector3.zero, Quaternion.identity, transform);
        rail.transform.localPosition = new Vector3(0f, -0.5f, 0f);
        rail.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        if (random == 1){
            target.SetActive(true);
            trigger.SetActive(true);
        }

        if(transform.position.z <= -45){
            if (Random.Range(0, 100) >= 80)
            {
            GameObject enemy = Instantiate(EnemySign, Vector3.zero, Quaternion.identity, transform);
            enemy.transform.localPosition = new Vector3(2.41f, -0.1f, 0f);
            //enemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }

        if(transform.position.z <= -45){
            if (Random.Range(0, 100) >= 80)
            {
                GameObject roc = Instantiate(RocSign, Vector3.zero, Quaternion.identity, transform);
                random = Random.Range(0, 100);
                float position = 0f;
                if (random < 50){
                    position = -0.1f;
                }else if (random >= 50)
                {
                    position = 0.1f;
                }
                
                roc.transform.localPosition = new Vector3(position, -0.5f, 0f);
                roc.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
        
    }

    void Update()
    {
        if(Settings._isAlive){
            speed = Settings.speed_block;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && Settings._isAlive)
        {
            StartCoroutine(DelayedAction());
        }
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
