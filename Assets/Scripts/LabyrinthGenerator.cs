using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    private Room[,] labyrinth;

    void Start()
    {
        InitializeLabyrinth();
        GenerateLabyrinth(0, 0);
        // Appelle ici toute méthode supplémentaire pour visualiser le labyrinthe
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
        public bool[] walls = new bool[4]; // Order: N, S, E, W

        public Room()
        {
            for (int i = 0; i < 4; i++)
            {
                walls[i] = false;
            }
        }
    }
}
