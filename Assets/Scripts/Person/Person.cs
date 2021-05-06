using System;
using System.Collections.Generic;
using Dialog;
using UnityEngine;

namespace Person
{
    [Serializable]
    public class DialogOptions
    {
        public DialogContext dialogContext;
        public List<Dialog.Dialog> dialogText;
    }

    [Serializable]
    public class DiscrepancyOptions
    {
        public Discrepancy.CheckableComponentType discrepancyComponent1;
        public Discrepancy.CheckableComponentType discrepancyComponent2;
    }

    [CreateAssetMenu(fileName = "New Person", menuName = "Person")]
    public class Person : ScriptableObject
    {
        public List<DialogOptions> dialogs;
        public List<DiscrepancyOptions> discrepancies;
        public bool isAllowed;
    }
}