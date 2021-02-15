using UnityEditor;
using UnityEngine;


namespace GeekBrains.Editor
{
    public class GameDesignerWindow : EditorWindow
    {
        #region Fields

        public static GameObject ObjectInstatiate;
        private Color _color;
        private string _nameObject = "Hello, Unity!";
        private bool _isGroupEnabled;
        private bool _isRandomColor = true;
        private int _countObject = 1;
        private int _minCountObject = 1;
        private int _maxCountObject = 100;
        private float _minRadius = 10.0f;
        private float _maxRadius = 100.0f;
        private float _radius = 10.0f;

        #endregion


        #region UnityMethods

        private void OnGUI()
        {
            GUILayout.Label("Настройки", EditorStyles.boldLabel);
            ObjectInstatiate = EditorGUILayout.ObjectField("Выбрать объект:",
                ObjectInstatiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            _isGroupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", _isGroupEnabled);
            _isRandomColor = EditorGUILayout.Toggle("Случайный цвет", _isRandomColor);
            _countObject = EditorGUILayout.IntSlider("Желаемое количество объектов", _countObject, _minCountObject, _maxCountObject);

            _radius = EditorGUILayout.Slider("Желаемый радиус окружности:", _radius, _minRadius, _maxRadius);
            EditorGUILayout.EndToggleGroup();

            var buttonInstatiateAndColor = GUILayout.Button("Создать объекты");
            if (buttonInstatiateAndColor)
            {
                CreateObjects();
            }

            GUILayout.Label("Раскрасить объекты вручную", EditorStyles.boldLabel);
            _color = EditorGUILayout.ColorField("Color", _color);

            if (GUILayout.Button("Закрасить"))
            {
                GetColor();
            }

        }

        #endregion


        #region Methods

        [MenuItem("Window/GeekBrains/GameDesignerWindow")]
        public static void ShowItem()
        {
            GetWindow<GameDesignerWindow>("Instatiate Objects");
        }

        private void CreateObjects()
        {
            if (ObjectInstatiate)
            {
                GameObject root = new GameObject("Root");
                for (int i = 0; i < _countObject; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 position = new Vector3(Mathf.Cos(angle), 0.0f,
                        Mathf.Sin(angle)) * _radius;
                    GameObject temp = Instantiate(ObjectInstatiate, position,
                        Quaternion.identity);
                    temp.name = _nameObject + "[" + i + "]";
                    temp.transform.parent = root.transform;
                    var tempRenderer = temp.GetComponent<Renderer>();
                    if (tempRenderer && _isRandomColor)
                    {
                        tempRenderer.material.color = Random.ColorHSV();
                    }

                }
            }
        }

        private void GetColor()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                var renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial.color = _color;
                }
            }

        }

        #endregion
    }
}
