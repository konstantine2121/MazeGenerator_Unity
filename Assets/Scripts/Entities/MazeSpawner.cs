using System;
using Assets.Scripts.ScriptableObjects;
using MazeGenerating;
using MazeGenerating.Data;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class MazeSpawner : MonoBehaviour
    {

        [SerializeField][Range(1,50)] private int mazeWidth = 1;
        [SerializeField][Range(1,50)] private int mazeHeight = 1;
        
        private WallFactory _wallFactory;
        private Maze _maze;

        private void Awake()
        {
            _wallFactory = WallFactory.Instance;
        }

        private void Start()
        {
            SpawnMaze();
        }

        public void SpawnMaze()
        {
            RemoveWalls();
            _maze = MazeGenerator.Generate(new Size(mazeWidth, mazeHeight));
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
                        _wallFactory.Create(this, i, j);
                    }
                }
            }
        }

        private void RemoveWalls()
        {
            var walls = GetComponentsInChildren<Wall>();

            foreach (var wall in walls) 
            {
                GameObject.Destroy(wall.gameObject);
            }
        }
    }
}