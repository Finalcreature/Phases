using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRoomPortal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject teenRoomPoint;
    [SerializeField] DoorCont childDoor;

    private bool isInRoom;

    // Start is called before the first frame update
    void Start()
    {
        //childCam.SetActive(false);
        isInRoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (childDoor.GetIsRoomClear() && isInRoom)
        //{
        //    childCam.SetActive(true);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (childDoor.GetIsRoomClear() && other.transform.name == "Player")
        {
            isInRoom = false;
            //childCam.SetActive(false);
            player.transform.position = teenRoomPoint.transform.position;
            player.transform.rotation = teenRoomPoint.transform.rotation;
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            FindObjectOfType<MusicManager>().ChangeSong();
        }
    }
}
