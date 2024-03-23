#!/usr/bin/python3
import csv
from sys import argv
import math
import random

lenght = 43
height = 43
Labyrinth = [ [[0, 0, 0, 0] for i in range(lenght)] for j in range(height)]

def is_explored(cell):
    for i in range(4):
        if (cell[i] == 1):
            return 1
    return 0

def get_nb_non_explored(x, y):
    total = []

    if (y + 1 < height and is_explored(Labyrinth[y + 1][x]) == 0):
        total.append("S")
    if (x + 1 < lenght and is_explored(Labyrinth[y][x + 1]) == 0):
        total.append("E")
    if (y - 1 >= 0 and is_explored(Labyrinth[y - 1][x]) == 0):
        total.append("N")
    if (x - 1 >= 0 and is_explored(Labyrinth[y][x - 1]) == 0):
        total.append("O")
    return total

def open_all_doors(x, y):
    nb = get_nb_non_explored(x, y)
    while (len(nb) > 0):
        direc = nb[random.randrange(0, len(nb))]
        if (direc == 'S'):
            Labyrinth[y][x][1] = 1
            Labyrinth[y + 1][x][0] = 1
            open_all_doors(x, y + 1)
        if (direc == 'E'):
            Labyrinth[y][x][2] = 1
            Labyrinth[y][x + 1][3] = 1
            open_all_doors(x + 1, y)
        if (direc == 'N'):
            Labyrinth[y][x][0] = 1
            Labyrinth[y - 1][x][1] = 1
            open_all_doors(x, y - 1)
        if (direc == 'O'):
            Labyrinth[y][x][3] = 1
            Labyrinth[y][x - 1][2] = 1
            open_all_doors(x - 1, y)
        print(direc)
        nb = get_nb_non_explored(x, y)
    return 0

def print_labyrinth():
    for i in range(height):
        for j in range(lenght):
            if (Labyrinth[i][j][0] == 1):
                print('┌ ', end="┐")
            else :
                print('┌─', end="┐")
        print("")
        for j in range(lenght):
            if (Labyrinth[i][j][3] == 1):
                print(' ', end=" ")
            else :
                print('│', end=" ")
            if (Labyrinth[i][j][2] == 1):
                print(' ', end="")
            else :
                print('│', end="")
        print("")
        for j in range(lenght):
            if (Labyrinth[i][j][1] == 1):
                print('└ ', end="┘")
            else :
                print('└─', end="┘")
        print("")

print_labyrinth()


# tests that the get_nb_non_explored fonction work
print(get_nb_non_explored(0,0))
print(get_nb_non_explored(1,0))
print(get_nb_non_explored(1,1))

open_all_doors(0, 0)
print_labyrinth()
