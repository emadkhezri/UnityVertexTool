namespace com.emadkhezri.vertextool
{
    using UnityEngine;
    using UnityEngine.Rendering;

    public class VertexToolData
    {
        public static string NO_OBJECT_SELECTED = "No Object Selected";
        public string selectedObjectName = NO_OBJECT_SELECTED;
        public bool isVertexSelected = false;
        public int vertexCount = 0;
        public int subMeshCount=0;
        public IndexFormat IndexFormat;
        public VertexData VertexData=new VertexData();
        public MeshFilter meshFilter;
        public bool vertexToolSettingsToggle = false;
        public bool vertexToolInfoToggle = true;
        public Color normalArrowColor = new Color(0.7f, 0.4f, 0.2f, 0.3f);
        public Color solidDiskColor = new Color(0.7f, 0.4f, 0.2f, 0.3f);
        public Color selectedVertexColor = Color.red;
        public float normalArrowSize = 0.5f;
        public float solidDiskSize = 0.2f;
        public float selectedVertexSize = 0.05f;
    }

    public class VertexData
    {
        public int Index;
        public Vector3 Position;
        public Vector3 Normal;
        public Vector3 Tangent;
        public Color Color;
        public Vector2 UV;
        public Vector2 UV2;
        public Vector2 UV3;
        public Vector2 UV4;
    }

}