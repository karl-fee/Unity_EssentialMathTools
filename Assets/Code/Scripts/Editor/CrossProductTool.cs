using UnityEngine;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine.Video;

public class CrossProductTool : CommonEditor, IUpdateSceneGUI
{
    public Vector3 m_p;
    public Vector3 m_q;
    public Vector3 m_pxq;

    private SerializedObject obj;
    private SerializedProperty propP;
    private SerializedProperty propQ;
    private SerializedProperty propPXQ;
    private GUIStyle guiStyle = new GUIStyle();

    [MenuItem("Tools/Cross Product Tool")]
    public static void ShowWindow(){
        GetWindow(typeof(CrossProductTool), true, "Cross Product");
    }

    private void SetDefaultValues(){
        m_p = new Vector3(0.0f, 1.0f, 0.0f);
        m_q = new Vector3(1.0f, 0.0f, 0.0f);
    }

    private void OnEnable(){

        if(m_p == Vector3.zero && m_q == Vector3.zero){
            SetDefaultValues();
        }

        obj = new SerializedObject(this);
        propP = obj.FindProperty("m_p");
        propQ = obj.FindProperty("m_q");
        propPXQ = obj.FindProperty("m_pxq");

        guiStyle.fontSize = 25;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.white;

        SceneView.duringSceneGui -= SceneGUI;
    }

    private void OnDisable(){
        SceneView.duringSceneGui += SceneGUI;
    }

    private void OnGUI(){
        obj.Update();
        DrawBlockGUI("P", propP);
        DrawBlockGUI("Q", propQ);
        DrawBlockGUI("PXQ", propPXQ);

        if(obj.ApplyModifiedProperties()){
            SceneView.RepaintAll();
        }
        
        if(GUILayout.Button("Reset Values")){
            SetDefaultValues();
        }

    }

    public void SceneGUI(SceneView view){
        throw new System.NotImplementedException();
    }

    private void DrawLineGUI(Vector3 pos, string tex, Color col){
        Handles.color = col;
        Handles.Label(pos, tex, guiStyle);
        Handles.DrawAAPolyLine(3f, pos, Vector3.zero);
    }

    private void RepaintOnGUI(){
        Repaint();
    }

    Vector3 CrossProduct(Vector3 p, Vector3 q){
        float x = p.y * q.z - p.z * q.y;
        float y = p.z * q.x - p.x * q.z;
        float z = p.x * q.y - p.y * q.x;

        return new Vector3(x, y, z);
    }

}
