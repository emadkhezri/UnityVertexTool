namespace com.emadkhezri.vertextool
{
    using UnityEditor;
    using UnityEngine;
    public class VertexInfoPanel
    {
        VertexToolData _toolData;

        public VertexInfoPanel(VertexToolData data)
        {
            _toolData = data;
        }

        public void OnGUI()
        {
            _toolData.vertexToolInfoToggle = EditorGUILayout.Foldout(_toolData.vertexToolInfoToggle, "Vertex Information");
            if (_toolData.vertexToolInfoToggle)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.LabelField($"Selected Object Name: {_toolData.selectedObjectName}");
                EditorGUILayout.LabelField($"Vertex Count: {_toolData.vertexCount}");
                EditorGUILayout.LabelField($"Sub Mesh Count: {_toolData.subMeshCount}");
                EditorGUILayout.LabelField($"Index Format: {_toolData.IndexFormat}");
                EditorGUILayout.BeginToggleGroup("Selected Vertex Info", true);
                SelectedInfoGUI();
                EditorGUILayout.EndToggleGroup();
                EditorGUILayout.EndVertical();
                EditorGUI.indentLevel--;
            }
        }

        private void SelectedInfoGUI()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField($"Index: {_toolData.VertexData.Index}");
            _toolData.VertexData.Position=EditorGUILayout.Vector3Field("Position", _toolData.VertexData.Position);
            _toolData.VertexData.Normal=EditorGUILayout.Vector3Field("Normal", _toolData.VertexData.Normal);
            _toolData.VertexData.Tangent=EditorGUILayout.Vector3Field("Tangent", _toolData.VertexData.Tangent);
            _toolData.VertexData.Color=EditorGUILayout.ColorField("Color", _toolData.VertexData.Color);
            _toolData.VertexData.UV = EditorGUILayout.Vector2Field("UV1", _toolData.VertexData.UV);
            _toolData.VertexData.UV2=EditorGUILayout.Vector2Field("UV2", _toolData.VertexData.UV2);
            _toolData.VertexData.UV3=EditorGUILayout.Vector2Field("UV3", _toolData.VertexData.UV3);
            _toolData.VertexData.UV4=EditorGUILayout.Vector2Field("UV4", _toolData.VertexData.UV4);
            EditorGUI.indentLevel--;
        }
    }

}