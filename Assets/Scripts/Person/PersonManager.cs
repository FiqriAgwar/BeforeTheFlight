using System.Collections.Generic;
using Dialog;
using Discrepancy;
using UnityEngine;
using UnityEngine.UI;

namespace Person
{
    public class PersonManager : MonoBehaviour
    {
        [SerializeField] private DialogManager dialogManager;
        [SerializeField] private DiscrepancyManager discrepancyManager;
        [SerializeField] private List<Person> personQueue;

        //TODO: Remove after visual system done
        [SerializeField] private Text debugText;

        private Person _currentPerson;

        public void NextPerson()
        {
            _currentPerson = personQueue[0];
            dialogManager.CurrentPerson = _currentPerson;
            discrepancyManager.CurrentPerson = _currentPerson;
            personQueue.RemoveAt(0);

            debugText.text = _currentPerson.name;
        }

        public void DebugShowDialog()
        {
            if (!dialogManager.ShowNextDialog(false))
            {
                Debug.Log("No dialog");
            }
        }
    }
}