using UnityEngine;


namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        Action currentAction;

        public void StartAction(Action action)
        {
            if (currentAction == action) return;

            if (currentAction != null)
            {
                currentAction.Cancel();
            }

            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}
