using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGenerator : MonoBehaviour
{
    public GameObject roomPrefab1; // Préfabriqué de la salle 1 (sans clé, ni coffre, ni spawn)
    public GameObject roomPrefab2; // Préfabriqué de la salle 2 (avec clé)
    public GameObject roomPrefab3; // Préfabriqué de la salle 3 (avec coffre)
    public GameObject roomPrefab4; // Préfabriqué de la salle 4 (avec spawn et porte de sortie)
    public GameObject player; // Joueur
    public int width = 10;
    public int height = 10;
    private Room[,] labyrinth;

    void Start()
    {
        InitializeLabyrinth();
        GenerateLabyrinth(0, 0);
        set_start_key_chest();
        InstantiateRooms();
    }
    void InitializeLabyrinth()
    {
        labyrinth = new Room[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                labyrinth[i, j] = new Room();
            }
        }
    }

    List<string> GetUnexploredNeighbors(int x, int y)
    {
        List<string> neighbors = new List<string>();

        if (y + 1 < height && !IsExplored(labyrinth[y + 1, x])) neighbors.Add("S");
        if (x + 1 < width && !IsExplored(labyrinth[y, x + 1])) neighbors.Add("E");
        if (y - 1 >= 0 && !IsExplored(labyrinth[y - 1, x])) neighbors.Add("N");
        if (x - 1 >= 0 && !IsExplored(labyrinth[y, x - 1])) neighbors.Add("W");

        return neighbors;
    }

    bool IsExplored(Room room)
    {
        if (room == null) return true;

        foreach (bool wall in room.walls)
        {
            if (wall) return true;
        }
        return false;
    }

    public void GenerateLabyrinth(int x, int y)
    {
        List<string> neighbors = GetUnexploredNeighbors(x, y);

        while (neighbors.Count > 0)
        {
            string direction = neighbors[Random.Range(0, neighbors.Count)];

            switch (direction)
            {
                case "N":
                    labyrinth[y, x].walls[0] = true;
                    labyrinth[y - 1, x].walls[1] = true;
                    GenerateLabyrinth(x, y - 1);
                    break;
                case "S":
                    labyrinth[y, x].walls[1] = true;
                    labyrinth[y + 1, x].walls[0] = true;
                    GenerateLabyrinth(x, y + 1);
                    break;
                case "E":
                    labyrinth[y, x].walls[2] = true;
                    labyrinth[y, x + 1].walls[3] = true;
                    GenerateLabyrinth(x + 1, y);
                    break;
                case "W":
                    labyrinth[y, x].walls[3] = true;
                    labyrinth[y, x - 1].walls[2] = true;
                    GenerateLabyrinth(x - 1, y);
                    break;
            }

            neighbors = GetUnexploredNeighbors(x, y);
        }
    }

    public class Room
    {
        public bool[] walls = new bool[4]; // N, S, E, W
        public bool[] type = new bool[3]; // Start, Key, Chest

        public Room()
        {
            for (int i = 0; i < 4; i++)
            {
                walls[i] = false;
            }
        }
    }
    void set_start_key_chest()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        labyrinth[y, x].type[0] = true;
        while (labyrinth[y, x].type[0])
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
        }
        labyrinth[y, x].type[1] = true;
        while (labyrinth[y, x].type[0] || labyrinth[y, x].type[1])
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
        }
        labyrinth[y, x].type[2] = true;
    }
    void InstantiateRooms()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Room room = labyrinth[i, j];
                GameObject roomPrefab = GetRoomPrefab(room);
                string[] walls = { "N", "S", "W", "E" };
                if (roomPrefab != null)
                {
                    // Instancier la salle dans la scène principale
                    GameObject newRoom = Instantiate(roomPrefab, new Vector3(j * 10, 1, i * 10), Quaternion.identity); // 5 is the size of each room, adjust as needed
                    newRoom.name = "Room_" + i + "_" + j;
                    newRoom.SetActive(true);
                    for (int k = 0; k < 4; k++)
                    {
                        if (room.walls[k]) {
                            newRoom.transform.Find("Wall_" + walls[k]).gameObject.SetActive(false);
                        }
                    }
                    if (room.type[0]) {
                        player.transform.position = new Vector3(j, 1, i);
                    }
                }
            }
        }
    }

    GameObject GetRoomPrefab(Room room)
    {
        if (room.type[0]) return roomPrefab4;
        if (room.type[1]) return roomPrefab2;
        if (room.type[2]) return roomPrefab3;
        return roomPrefab1;
    }
}