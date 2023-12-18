using Assets.Scripts.Entities;
using MazeGenerating.Data;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObject/WallFactory")]
    public class WallFactory : ScriptableObject
    {
        #region Fields

        private static WallFactory _instance;

        [SerializeField] private Wall _wall;

        #endregion Fields

        #region Properties

        public static WallFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Load();
                }

                return _instance;
            }
        }

        #endregion Properties

        #region Methods

        private static WallFactory Load()
        {
            var path = "ScriptableObjects/WallFactory";
            var container = Resources.Load<WallFactory>(path);

            return container;
        }

        public Wall Create(MazeSpawner mazeSpawner)
        {
            var spawnerTransform = mazeSpawner.transform;
            var wall = Instantiate(_wall, spawnerTransform.position, spawnerTransform.rotation);

            wall.transform.SetParent(spawnerTransform, true);

            return wall;
        }

        public Wall Create(MazeSpawner mazeSpawner, int row, int column)
        {
            var spawnerTransform = mazeSpawner.transform;
            var wall = Instantiate(_wall);

            var stepOffset = wall.GetComponent<BoxCollider>().size.x;
            wall.transform.position = CalculeteWallPosition(stepOffset, row, column);

            wall.transform.SetParent(spawnerTransform, false);

            return wall;
        }

        private Vector3 CalculeteWallPosition(float stepOffset, int row, int column)
        {
            return new Vector3(row * stepOffset, 0, column * stepOffset);
        }

        #endregion Methods

        /*
        /// <summary>
        /// Нажатая клетка.
        /// </summary>
        public Texture2D DeadCell => _deadCell;

        public Texture2D GetNextTexture()
        {
            return GetRandomTexture(_texturesArray);
        }

        private Texture2D GetRandomTexture(Texture2D[] array)
        {
            if (array.Length == 0)
            {
                return null;
            }
            var index = Random.Range(0, array.Length);
            return array[index];
        }
        */
    }
}