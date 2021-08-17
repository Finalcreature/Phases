using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElderRoomPortal : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject ElderCam;
    [SerializeField] ElderDoorCont ElderDoor;
    [SerializeField] GameObject SpawnInBabyRoomLocation;
    [SerializeField] GameObject Panel;

    float transparentTimer;
    private bool isInRoom;

    // Start is called before the first frame update
    void Start()
    {
        ElderCam.SetActive(false);
        isInRoom = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (ElderDoor.GetIsRoomClear() && isInRoom)
        {
            ElderCam.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (ElderDoor.GetIsRoomClear() && other.transform.name == "Player")
        {
            isInRoom = false;
            ElderCam.SetActive(false);
            player.transform.position = SpawnInBabyRoomLocation.transform.position;
            player.transform.rotation = SpawnInBabyRoomLocation.transform.rotation;
            player.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            FindObjectOfType<MusicManager>().ChangeSong();

            FindObjectOfType<PlayerMovement>().enabled = false;
            FindObjectOfType<PlayerLookAround>().enabled = false;
            Panel.SetActive(true);
        }
    }

    
}
