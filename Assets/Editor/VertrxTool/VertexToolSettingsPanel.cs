using UnityEditor;

public class VertexToolSettingsPanel
{
    VertexToolData _data;

    public VertexToolSettingsPanel(VertexToolData data)
    {
        _data = data;
    }

    public void OnGUI()
    {
        _data.vertexToolSettingsToggle = EditorGUILayout.Foldout(_data.vertexToolSettingsToggle, "Vertex Tool Settings");
        if (_data.vertexToolSettingsToggle)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _data.normalArrowColor = EditorGUILayout.ColorField("Vertex Normal Arrow Color", _data.normalArrowColor);
            _data.solidDiskColor = EditorGUILayout.ColorField("Vertex Solid Disk Color", _data.solidDiskColor);
            _data.selectedVertexColor = EditorGUILayout.ColorField("Selected Vertex Color", _data.selectedVertexColor);
            _data.normalArrowSize = EditorGUILayout.FloatField("Vertex Normal Arrow Size", _data.normalArrowSize);
            _data.solidDiskSize = EditorGUILayout.FloatField("Vertex Solid Disk Size", _data.solidDiskSize);
            _data.selectedVertexSize = EditorGUILayout.FloatField("Selected Vertex Size", _data.selectedVertexSize);
            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel--;
        }
    }
}
