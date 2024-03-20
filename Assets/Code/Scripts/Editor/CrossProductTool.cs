using UnityEngine;
using UnityEditor;

public class CrossProductTool : EditorWindow
{
    public Vector3 m_p;
    public Vector3 m_q;
    public Vector3 m_pxq;

    [MenuItem("Tools/Cross Product Tool")]
    public static void ShowWindow(){
        GetWindow(typeof(CrossProductTool), true, "Cross Product");
    }
}
