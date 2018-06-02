namespace com.emadkhezri.vertextool
{
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
            _data.subMeshCount = 0;
            _data.VertexData.Index = 0;
            _data.VertexData.Position = Vector3.zero;
            _data.VertexData.Normal = Vector3.zero;
            _data.VertexData.Tangent = Vector3.zero;
            _data.VertexData.Color = Color.clear;
            _data.VertexData.UV = Vector3.zero;
            _data.VertexData.UV2 = Vector3.zero;
            _data.VertexData.UV3 = Vector3.zero;
            _data.VertexData.UV4 = Vector3.zero;
            EditorWindow.GetWindow<VertexToolWindow>().Repaint();
        }

        public void ProcessSelected(Vector3 hitPoint)
        {
            Mesh mesh = _data.meshFilter.sharedMesh;
            _data.vertexCount = mesh.vertices.Length;
            _data.subMeshCount = mesh.subMeshCount;
            _data.IndexFormat = mesh.indexFormat;
            var currentSelectedVertex = _data.VertexData.Index;
            _data.VertexData.Index = findSelectedVertexIndex(mesh.vertices, hitPoint - _data.meshFilter.transform.position);
            if (currentSelectedVertex == _data.VertexData.Index)
                return;
            _data.VertexData.Position = mesh.vertices[_data.VertexData.Index];
            _data.VertexData.Normal = mesh.normals[_data.VertexData.Index];
            _data.VertexData.Tangent = mesh.tangents[_data.VertexData.Index];
            if (_data.VertexData.Index < mesh.colors.Length)
                _data.VertexData.Color = mesh.colors[_data.VertexData.Index];

            if (_data.VertexData.Index < mesh.uv.Length)
                _data.VertexData.UV = mesh.uv[_data.VertexData.Index];

            if (_data.VertexData.Index < mesh.uv2.Length)
                _data.VertexData.UV2 = mesh.uv2[_data.VertexData.Index];

            if (_data.VertexData.Index < mesh.uv3.Length)
                _data.VertexData.UV3 = mesh.uv3[_data.VertexData.Index];

            if (_data.VertexData.Index < mesh.uv4.Length)
                _data.VertexData.UV4 = mesh.uv4[_data.VertexData.Index];

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

}