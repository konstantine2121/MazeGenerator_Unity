using Assets.Scripts.Entities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.CustomEditors
{
    [CustomEditor(typeof(MazeSpawner))]
    public class MazeSpawnerEditor : Editor
    {
        private const string WidthMark = "width";
        private const string HeightMark = "height";
        private const string GenerateMark = "generate";
        private const string RemoveMark = "remove";

        private IntegerField _widthField;
        private IntegerField _heightField;
        private Button _generateButton;
        private Button _removeButton;

        private VisualElement InspectorRoot { get; set; }

        private MazeSpawner MazeSpawner => target as MazeSpawner;

        public override VisualElement CreateInspectorGUI()
        {
            InspectorRoot = new VisualElement();

            // Load and clone a visual tree from UXML
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/UI/CustomEditors/MazeSpawnerView.uxml");
            visualTree.CloneTree(InspectorRoot);
            Initialize();

            return InspectorRoot;
        }

        private void Initialize()
        {
            _widthField = InspectorRoot.Q<IntegerField>(WidthMark);
            _heightField = InspectorRoot.Q<IntegerField>(HeightMark);

            _generateButton = InspectorRoot.Q<Button>(GenerateMark);
            _generateButton.clicked += OnGenerateButtonClicked;

            _removeButton = InspectorRoot.Q<Button>(RemoveMark);
            _removeButton.clicked += OnRemoveButtonClicked;
        }

        private void OnRemoveButtonClicked()
        {
            MazeSpawner.RemoveWalls();
        }

        private void OnGenerateButtonClicked()
        {
            MazeSpawner.SpawnMaze();
        }
    }
}