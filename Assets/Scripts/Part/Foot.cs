using System.Collections.Generic;
using UnityEngine;

namespace Part
{
    public enum FootSkill
    {
        DoubleJump,
        AirJet,
        踏云行,
        闪电战术
    }
    
    [CreateAssetMenu(fileName = "Part", menuName = "Part/Foot", order = 1)]
    public class Foot : Parts
    {
        public FootSkill footSkill;
    }
}