using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public float speed = Settings.speed_block;
    [SerializeField] 
    private GameObject rail;
    [SerializeField] 
    private GameObject target;
    [SerializeField] 
    private GameObject trigger;
    [SerializeField]
    private List<Mesh> list_mesh;
    [SerializeField] 
    private  List<Mesh> list_mesh_rail;
    private MeshFilter meshFilter;
    private MeshFilter meshFilter_rail;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = list_mesh[Random.Range(0, list_mesh.Count)];

        int random = Random.Range(0, list_mesh_rail.Count);
        meshFilter_rail = rail.GetComponent<MeshFilter>();
        meshFilter_rail.mesh = list_mesh_rail[random];
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
