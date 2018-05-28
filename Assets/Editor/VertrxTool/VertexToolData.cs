using UnityEngine;

public class VertexToolData {
    public static string NO_OBJECT_SELECTED = "No Object Selected";
    public string selectedObjectName = NO_OBJECT_SELECTED;
    public bool isVertexSelected = false;
    public int vertexCount = 0;
    public int vertexIndex = 0;
    public MeshFilter meshFilter;
    public Vector3 vertexPosition = Vector3.zero;
    public Vector3 vertexNormal = Vector3.zero;
    public Vector3 vertexTangent = Vector3.zero;
    public Color vertexColor = Color.clear;
    public Vector2 vertexUV = Vector3.zero;
    public Vector2 vertexUV2 = Vector3.zero;
    public Vector2 vertexUV3 = Vector3.zero;
    public Vector2 vertexUV4 = Vector3.zero;
    public bool vertexToolSettingsToggle = false;
    public bool vertexToolInfoToggle = true;
    public Color normalArrowColor = new Color(0.7f, 0.4f, 0.2f, 0.3f);
    public Color solidDiskColor = new Color(0.7f, 0.4f, 0.2f, 0.3f);
    public Color selectedVertexColor = Color.red;
    public float normalArrowSize = 0.5f;
    public float solidDiskSize = 0.2f;
    public float selectedVertexSize = 0.05f;
}
