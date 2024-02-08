using UnityEngine;

namespace ScriptsObject
{
    [CreateAssetMenu(fileName = "Part", menuName = "Part/Foot")]
    public class Foot : Parts
    {
        public override void Skill()
        {
            base.Skill();
            Debug.Log("脚步技能");
        }
    }
}