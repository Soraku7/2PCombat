using UnityEngine;

namespace ScriptsObject
{
    [CreateAssetMenu(fileName = "Part", menuName = "Part/Head")]
    public class Head : Parts
    {
        public GameObject instantiateObject;
        public override void Skill()
        {
            base.Skill();
            Debug.Log("头部技能");
        }
    }
}