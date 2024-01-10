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
