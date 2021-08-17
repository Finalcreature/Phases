using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenRoomPortal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject adultRoomPoint;
    [SerializeField] TeenDoorCont teenDoor;

    private bool isInRoom;

    // Start is called before the first frame update
    void Start()
    {
        //teenCam.SetActive(false);
        isInRoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (teenDoor.GetIsRoomClear() && isInRoom)
        //{
        //    teenCam.SetActive(true);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (teenDoor.GetIsRoomClear() && other.transform.name == "Player")
        {
            isInRoom = false;
            //teenCam.SetActive(false);
            player.transform.position = adultRoomPoint.transform.position;
            player.transform.rotation = adultRoomPoint.transform.rotation;
            player.transform.localScale = new Vector3(0.5f, 0.75f, 0.5f);
            FindObjectOfType<MusicManager>().ChangeSong();
        }
    }
}
