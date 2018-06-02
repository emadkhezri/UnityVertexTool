namespace com.emadkhezri.vertextool
{
    using UnityEditor;
    using UnityEngine;

    public class VertexToolSceneManager
    {
        VertexProcessor _vertexProcessor;
        VertexToolData _data;

        public VertexToolSceneManager(VertexToolData data)
        {
            _data = data;
            _vertexProcessor = new VertexProcessor(_data);
        }

        public void OnSceneGUI(SceneView sceneView)
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    _data.meshFilter = GetMeshFilter(hit.transform);
                    _data.selectedObjectName = _data.meshFilter.name;
                    if (_data.meshFilter != null)
                    {
                        _data.isVertexSelected = true;
                        _vertexProcessor.ProcessSelected(hit.point);
                        return;
                    }
                    _data.isVertexSelected = false;
                }
                else
                {
                    _data.isVertexSelected = false;
                    _data.selectedObjectName = VertexToolData.NO_OBJECT_SELECTED;
                    _data.meshFilter = null;
                }
                _vertexProcessor.Clean();
            }

            if (_data.isVertexSelected)
            {
                var disPosition = _data.VertexData.Position + _data.meshFilter.transform.position;
                Handles.Label(disPosition, "Selected Vertex");
                Handles.color = _data.normalArrowColor;
                Handles.ArrowHandleCap(0, disPosition, Quaternion.LookRotation(_data.VertexData.Normal), _data.normalArrowSize, Event.current.type);
                Handles.color = _data.solidDiskColor;
                Handles.DrawSolidDisc(disPosition, _data.VertexData.Normal, _data.solidDiskSize);
                Handles.color = _data.selectedVertexColor;
                Handles.SphereHandleCap(0, disPosition, Quaternion.LookRotation(_data.VertexData.Normal), _data.selectedVertexSize, Event.current.type);
            }
        }
        
        private MeshFilter GetMeshFilter(Transform transform)
        {
            MeshFilter meshFilter = transform.GetComponentInChildren<MeshFilter>();
            while (meshFilter == null && transform.parent != null)
            {
                meshFilter = GetMeshFilter(transform.parent);
            }
            return meshFilter;
        }
    }

}