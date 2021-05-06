using Person;
using Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Discrepancy
{
    public class DiscrepancyManager : MonoBehaviour
    {
        [SerializeField] private CheckableComponent component1;
        [SerializeField] private CheckableComponent component2;

        [SerializeField] private bool _isComponent1Chosen = false;
        [SerializeField] private bool _isComponent2Chosen = false;

        private Person.Person _currentPerson;
        private List<DiscrepancyOptions> _discrepancyList;

        public Person.Person CurrentPerson
        {
            set
            {
                _currentPerson = value;
                _discrepancyList = _currentPerson.discrepancies;
                ResetDetector();
            }
        }

        public void RegisterComponent(CheckableComponent component)
        {
            if(!_isComponent1Chosen)
            {
                component1 = component;
                _isComponent1Chosen = true;
            }
            else if(!_isComponent2Chosen)
            {
                component2 = component;
                _isComponent2Chosen = true;
            }

            if(_isComponent1Chosen && _isComponent2Chosen)
            {
                DetectDiscrepancy();
            }
        }

        public void UnregisterComponent(CheckableComponent component)
        {
            if(_isComponent1Chosen && component1.Equals(component))
            {
                component1 = null;
                _isComponent1Chosen = false;
            } else if(_isComponent2Chosen && component2.Equals(component))
            {
                component2 = null;
                _isComponent2Chosen = false;
            }
        }

        private void ResetDetector()
        {
            if(_isComponent1Chosen)
            {
                if(component1)
                {
                    component1.ResetComponent();
                } else
                {
                    _isComponent1Chosen = false;
                }
            }

            if (_isComponent2Chosen)
            {
                if (component2)
                {
                    component2.ResetComponent();
                }
                else
                {
                    _isComponent2Chosen = false;
                }
            }
        }

        private void DetectDiscrepancy()
        {
            Debug.Log("Check Discrepancy");
            if(CheckDiscrepancy())
            {
                Debug.Log("Discrepancy Detected");
                Debug.Log("Item 1: " + component1.type.ToString());
                Debug.Log("Item 2: " + component2.type.ToString());

            } else
            {
                Debug.Log("Discrepancy Not Detected");

            }

            ResetDetector();
        }

        private bool CheckDiscrepancy()
        {
            foreach(DiscrepancyOptions discrepancy in _discrepancyList)
            {
                if (discrepancy.discrepancyComponent1 == component1.type &&
                   discrepancy.discrepancyComponent2 == component2.type)
                {
                    return true;
                } else if(discrepancy.discrepancyComponent1 == component2.type &&
                   discrepancy.discrepancyComponent2 == component1.type)
                {
                    return true;
                }
            }


            return false;
        }
    }
}


