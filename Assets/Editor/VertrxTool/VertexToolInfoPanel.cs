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
            EditorGUILayout.LabelField($"Vertex Index: {_data.vertexIndex}");
            EditorGUILayout.Vector3Field("Vertex Position", _data.vertexPosition);
            EditorGUILayout.Vector3Field("Vertex Normal", _data.vertexNormal);
            EditorGUILayout.Vector3Field("Vertex Tangent", _data.vertexTangent);
            EditorGUILayout.ColorField("Vertex Color", _data.vertexColor);
            EditorGUILayout.Vector2Field("Vertex UV1", _data.vertexUV);
            EditorGUILayout.Vector2Field("Vertex UV2", _data.vertexUV2);
            EditorGUILayout.Vector2Field("Vertex UV3", _data.vertexUV3);
            EditorGUILayout.Vector2Field("Vertex UV4", _data.vertexUV4);
            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel--;
        }
    }
}
