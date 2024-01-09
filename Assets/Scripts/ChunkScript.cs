using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    public float speed = Settings.speed_block;

    [SerializeField] 
    private List<Mesh> list_mesh;
    private MeshFilter meshFilter;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = list_mesh[Random.Range(0, list_mesh.Count)];
    }

    void Update()
    {
        speed = Settings.speed_block;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedAction());
        }
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
