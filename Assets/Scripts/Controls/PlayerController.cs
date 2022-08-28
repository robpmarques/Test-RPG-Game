using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;
using RPG.Core;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Fighter fighter;
        Health health;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            if (health.IsDead()) return;

            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit item in hits)
            {
                CombatTarget target = item.transform.GetComponent<CombatTarget>();

                if (target == null) continue;

                if (!fighter.CanAttack(target.gameObject)) continue;

                if (Input.GetMouseButton(0))
                {
                    fighter.Attack(target.gameObject);
                }

                return true;
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;

            bool isHit = Physics.Raycast(GetMouseRay(), out hit);

            if (Input.GetMouseButton(0))
            {
                if (isHit)
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
            }

            return isHit;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
