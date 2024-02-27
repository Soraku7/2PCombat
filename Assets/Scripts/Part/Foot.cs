using UnityEngine;

namespace Part
{
    public enum FootSkill
    {
        DoubleJump,
        空中喷射,
        踏云行,
        闪电战术
    }
    
    [CreateAssetMenu(fileName = "Part", menuName = "Part/Foot", order = 1)]
    public class Foot : Parts
    {
        public FootSkill footSkill;
    }
}