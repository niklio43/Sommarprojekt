using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour
{
    public Vector2 center;
    public int width, height;

    [SerializeField] public List<Doorway> doorsways;

    float startRot = 0;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        doorsways = new List<Doorway>(transform.GetComponentsInChildren<Doorway>());
        startRot = transform.eulerAngles.y;
    }

    public Doorway RandomDoor()
    {
        for (int i = 0; i < doorsways.Count; i++) {
            if(doorsways[i].isConnected) { doorsways.RemoveAt(i); i--; }
        }

        return doorsways[Random.Range(0, doorsways.Count)];
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector3(center.x, 0, center.y), new Vector3(width, 0, height));
    }

}
