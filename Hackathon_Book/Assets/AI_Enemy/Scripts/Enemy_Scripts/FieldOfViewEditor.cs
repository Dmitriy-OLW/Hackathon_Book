/*
using UnityEngine;
#if UNITY_EDITOR // => Ignore from here to next endif if not in editor
using UnityEditor;
#endif

[CustomEditor(typeof(Enemy_see))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        Enemy_see fov = (Enemy_see)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

       if (fov.canSeePlayer)
       {
           Handles.color = Color.red;
           Handles.DrawLine(fov.transform.position, fov.player.transform.position);
       }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
*/
