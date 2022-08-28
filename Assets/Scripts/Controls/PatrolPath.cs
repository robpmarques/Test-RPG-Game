using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        const float waypontGizmoRadius = 0.3f;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Vector3 childPosition = GetWaypoint(i);
                Vector3 nextChildrenPosition = GetWaypoint(j);

                Gizmos.color = Color.white;

                Gizmos.DrawSphere(childPosition, waypontGizmoRadius);
                Gizmos.DrawLine(childPosition, nextChildrenPosition);
            }
        }

        public int GetNextIndex(int i)
        {
            return (i + 1) % transform.childCount;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }


    }
}