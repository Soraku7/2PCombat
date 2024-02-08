using UnityEngine;

namespace ScriptsObject
{
    [CreateAssetMenu(fileName = "Part", menuName = "Part/Torso")]
    public class Torso : Parts
    {
        public float damage;
        public override void Skill()
        {
            base.Skill();
            Debug.Log("躯干技能");
        }
    }
}