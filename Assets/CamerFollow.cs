using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    public GameObject player;
    public GameObject Coin;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

