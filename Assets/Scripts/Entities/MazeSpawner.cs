using System;
using Assets.Scripts.ScriptableObjects;
using MazeGenerating;
using MazeGenerating.Data;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class MazeSpawner : MonoBehaviour
    {

        [SerializeField][Range(1,50)] private int _mazeWidth = 1;
        [SerializeField][Range(1,50)] private int _mazeHeight = 1;
        
        private Maze _maze;

        public void SpawnMaze()
        {
            RemoveWalls();
            _maze = MazeGenerator.Generate(new Size(_mazeWidth, _mazeHeight));
            SpawnWalls(_maze);
        }

        private void SpawnWalls(Maze maze)
        {
            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    var cellType = maze[j, i];

                    if (cellType == CellType.Wall)
                    {
                        WallFactory.Instance.Create(this, i, j);
                    }
                }
            }
        }

        public void RemoveWalls()
        {
            var walls = GetComponentsInChildren<Wall>();

            foreach (var wall in walls) 
            {
                GameObject.DestroyImmediate(wall.gameObject);
            }
        }
    }
}