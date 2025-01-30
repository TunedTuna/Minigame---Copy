using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset= transform.position-player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()//takes place after all other scripts, in event scripts move player obj
    {
        transform.position=player.transform.position +offset; //alaign camera before frame is displayed
    }
}
