﻿using UnityEditor;
using UnityEngine;

public class VertexToolSceneManager {
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
                _data.selectedObjectName = hit.transform.name;
                _data.meshFilter = hit.transform.GetComponent<MeshFilter>();
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
            var disPosition = _data.vertexPosition + _data.meshFilter.transform.position;
            Handles.Label(disPosition, "Selected Vertex");
            Handles.color = _data.normalArrowColor;
            Handles.ArrowHandleCap(0, disPosition, Quaternion.LookRotation(_data.vertexNormal), _data.normalArrowSize, Event.current.type);
            Handles.color = _data.solidDiskColor;
            Handles.DrawSolidDisc(disPosition, _data.vertexNormal, _data.solidDiskSize);
            Handles.color = _data.selectedVertexColor;
            Handles.SphereHandleCap(0, disPosition, Quaternion.LookRotation(_data.vertexNormal), _data.selectedVertexSize, Event.current.type);
        }
        else
        {
            Vector2 mousePosition = Event.current.mousePosition;
        }
    }
}