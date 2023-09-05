using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public TileBase[] openDoorTiles;   // Array of tiles for the open door
    private Tilemap tilemap;

    public List<Vector3Int> doorTilePositions = new List<Vector3Int>(); // The positions of the door tiles in the Tilemap grid.

    public string nextSceneName; // string of the next scene to load up

    private bool doorIsOpen = false;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();

    }

    public void OpenDoor()
    {
        for (int i = 0; i < doorTilePositions.Count; i++)
        {
            tilemap.SetTile(doorTilePositions[i], openDoorTiles[i]);
        }
        doorIsOpen = true;
    }

    private void Update()
    {
        // Check if the door is open and the player is pressing the 'Up' arrow key
        if (doorIsOpen && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}


