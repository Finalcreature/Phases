using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultRoomPortal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject ElderRoomPoint;
    [SerializeField] AdultDoor AdultDoor;

    private bool isInRoom;

    // Start is called before the first frame update
    void Start()
    {
       isInRoom = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (AdultDoor.GetIsRoomClear() && other.transform.name == "Player")
        {
            isInRoom = false;
            //AdultCam.SetActive(false);
            player.transform.position = ElderRoomPoint.transform.position;
            player.transform.rotation = ElderRoomPoint.transform.rotation;
            player.transform.localScale = new Vector3(0.5f, 0.75f, 0.5f);
            FindObjectOfType<MusicManager>().StopSong();
        }
    }
}
