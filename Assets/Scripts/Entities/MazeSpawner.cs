using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class MazeSpawner : MonoBehaviour
    {
        private WallFactory _wallFactory;

        private void Awake()
        {
            _wallFactory = WallFactory.Instance;
        }

        private void Start()
        {
            _wallFactory.Create(this);
        }
    }
}