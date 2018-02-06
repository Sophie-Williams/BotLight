using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BotLight
{

    [Serializable]
    public class Transition
    {
        public Decision decision;
        public State trueState;
        public State falseState;
    }
}
