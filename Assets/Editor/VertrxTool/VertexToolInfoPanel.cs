namespace com.emadkhezri.vertextool
{
    using UnityEditor;
    public class VertexInfoPanel
    {
        VertexToolData _data;

        public VertexInfoPanel(VertexToolData data)
        {
            _data = data;
        }

        public void OnGUI()
        {
            _data.vertexToolInfoToggle = EditorGUILayout.Foldout(_data.vertexToolInfoToggle, "Vertex Information");
            if (_data.vertexToolInfoToggle)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.LabelField($"Selected Object Name: {_data.selectedObjectName}");
                EditorGUILayout.LabelField($"Vertex Count: {_data.vertexCount}");
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
            EditorGUILayout.LabelField($"Index: {_data.vertexIndex}");
            EditorGUILayout.Vector3Field("Position", _data.vertexPosition);
            EditorGUILayout.Vector3Field("Normal", _data.vertexNormal);
            EditorGUILayout.Vector3Field("Tangent", _data.vertexTangent);
            EditorGUILayout.ColorField("Color", _data.vertexColor);
            EditorGUILayout.Vector2Field("UV1", _data.vertexUV);
            EditorGUILayout.Vector2Field("UV2", _data.vertexUV2);
            EditorGUILayout.Vector2Field("UV3", _data.vertexUV3);
            EditorGUILayout.Vector2Field("UV4", _data.vertexUV4);
            EditorGUI.indentLevel--;
        }
    }

}