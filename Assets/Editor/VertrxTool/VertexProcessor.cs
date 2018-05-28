using UnityEngine;
using UnityEditor;

public class VertexProcessor
{
    VertexToolData _data;

    public VertexProcessor(VertexToolData data)
    {
        _data = data;
    }

    public void Clean()
    {
        _data.vertexCount = 0;
        _data.vertexIndex = 0;
        _data.vertexPosition = Vector3.zero;
        _data.vertexNormal = Vector3.zero;
        _data.vertexTangent = Vector3.zero;
        _data.vertexColor = Color.clear;
        _data.vertexUV = Vector3.zero;
        _data.vertexUV2 = Vector3.zero;
        _data.vertexUV3 = Vector3.zero;
        _data.vertexUV4 = Vector3.zero;
        EditorWindow.GetWindow<VertexToolWindow>().Repaint();
    }

    public void ProcessSelected(Vector3 hitPoint)
    {
        Mesh mesh = _data.meshFilter.sharedMesh;
        _data.vertexCount = mesh.vertices.Length;
        _data.vertexIndex = findSelectedVertexIndex(mesh.vertices, hitPoint);
        _data.vertexPosition = mesh.vertices[_data.vertexIndex];
        _data.vertexNormal = mesh.normals[_data.vertexIndex];
        _data.vertexTangent = mesh.tangents[_data.vertexIndex];
        if (_data.vertexIndex < mesh.colors.Length)
            _data.vertexColor = mesh.colors[_data.vertexIndex];

        if (_data.vertexIndex < mesh.uv.Length)
            _data.vertexUV = mesh.uv[_data.vertexIndex];

        if (_data.vertexIndex < mesh.uv2.Length)
            _data.vertexUV2 = mesh.uv2[_data.vertexIndex];

        if (_data.vertexIndex < mesh.uv3.Length)
            _data.vertexUV3 = mesh.uv3[_data.vertexIndex];

        if (_data.vertexIndex < mesh.uv4.Length)
            _data.vertexUV4 = mesh.uv4[_data.vertexIndex];

        EditorWindow.GetWindow<VertexToolWindow>().Repaint();
    }

    private int findSelectedVertexIndex(Vector3[] vertices, Vector3 point)
    {
        float minDistance = float.MaxValue;
        int minIndex = 0;
        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Vector3.Distance(vertices[i], point);
            if (distance < minDistance)
            {
                minDistance = distance;
                minIndex = i;
            }
        }
        return minIndex;
    }
}
