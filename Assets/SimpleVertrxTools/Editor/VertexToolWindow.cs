﻿namespace com.emadkhezri.vertextool
{
    using UnityEngine;
    using UnityEditor;

    public class VertexToolWindow : EditorWindow
    {
        VertexToolData _data = new VertexToolData();
        public VertexInfoPanel _infoPanel;
        VertexToolSettingsPanel _settingsPanel;
        VertexToolSceneManager _sceneManager;

        [MenuItem("Window/Vertex Tool")]
        public static void ShowVertexInfo()
        {
            VertexToolWindow vertexInfoWindow = CreateInstance<VertexToolWindow>();
            vertexInfoWindow.titleContent = new GUIContent("Vertex Tool");
            vertexInfoWindow.Show();
        }

        private void OnEnable()
        {
            _infoPanel = new VertexInfoPanel(_data);
            _settingsPanel = new VertexToolSettingsPanel(_data);
            _sceneManager = new VertexToolSceneManager(_data);
            SceneView.duringSceneGui += _sceneManager.OnSceneGUI;
        }

        private void OnDisable()
        {
            SceneView.duringSceneGui -= _sceneManager.OnSceneGUI;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Vertex Tool", EditorStyles.boldLabel);
            _infoPanel.OnGUI();
            _settingsPanel.OnGUI();
        }
    } 
}
