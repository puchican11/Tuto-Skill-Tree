using UnityEngine;

namespace Puchican
{
    public class Skill : MonoBehaviour
    {
        public string SkillName;
        public string SkillDescription;

        public Sprite Icon;
        public float CostMoney;

        public bool IsUnlocked = false;
        public bool IsLaunched = false;

        public void StartAbiltity()
        {
            if(!IsLaunched)
            {
                OnStart();
            }
        }

        public virtual void OnStart()
        {
            Debug.Log($"{SkillName} vient de démarrer");
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnComplete()
        {
            Debug.Log($"{SkillName} vient de finir");
        }

        public virtual bool CanBeUnlocked()
        {
            if(SkillManager.Instance.Money < CostMoney)
            {
                return false;
            }

            return true;
        }
    }

}
