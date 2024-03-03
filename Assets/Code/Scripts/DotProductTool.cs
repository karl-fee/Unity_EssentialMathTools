using UnityEngine;
using UnityEditor;

public class DotProductEditor : EditorWindow
{
    public Vector3 m_p0;
    public Vector3 m_p1;
    public Vector3 m_c;

    private SerializedObject obj;
    private SerializedProperty propP0;
    private SerializedProperty propP1;
    private SerializedProperty propC;

    [MenuItem("Tools/Dot Product")]
    public static void ShowWindow() {
        DotProductEditor window = (DotProductEditor) GetWindow(typeof (DotProductEditor), true, "Dot Product");
        window.Show();
    }
    // Initialise vectors
    private void OnEnable(){
        if(m_p0 == Vector3.zero && m_p1 == Vector3.zero){

            m_p0 = new Vector3(0.0f, 1.0f, 0.0f);
            m_p1 = new Vector3(0.5f, 0.5f, 0.0f);
            m_c = Vector3.zero;
        }

        obj = new SerializedObject(this);
        propP0 = obj.FindProperty("m_p0");
        propP1 = obj.FindProperty("m_p1");
        propC = obj.FindProperty("m_c");

        SceneView.duringSceneGui += SceneGUI;
    }

    private void OnDisable(){
        SceneView.duringSceneGui += SceneGUI;
    }

    private void OnGUI(){

    }

    private void SceneGUI(SceneView view){
        //Debug.Log("Being Updated!");
        Handles.color = Color.red;
        Vector3 p0 = SetMovePoint(m_p0);
        Handles.color = Color.green;
        Vector3 p1 = SetMovePoint(m_p1);
        Handles.color = Color.white;
        Vector3 c = SetMovePoint(m_c);

        if(m_p0 != p0 || m_p1 != p1 || m_c != c){

            m_p0 = p0;
            m_p1 = p1;
            m_c = c;

            Repaint();
        }
    }

    Vector3 SetMovePoint(Vector3 pos){
        float size = HandleUtility.GetHandleSize(Vector3.zero) * 0.15f;
        var fmh_51_44_638450909898752133 = Quaternion.identity; return Handles.FreeMoveHandle(pos, size, Vector3.zero, Handles.SphereHandleCap);
    }
}