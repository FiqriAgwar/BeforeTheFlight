using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {
        public DialogContext currentContext = DialogContext.NOCONTEXT;

        private Person.Person _currentPerson;
        private Queue<Dialog> _dialogQueue;

        public Person.Person CurrentPerson
        {
            set
            {
                // TODO: Do something, reset dialog(?)
                _currentPerson = value;
                ResetConv();
            }
        }

        private void ResetConv()
        {
            var dialogOptions = _currentPerson.dialogs.Find(entry => entry.dialogContext == currentContext);
            _dialogQueue = new Queue<Dialog>(dialogOptions.dialogText);
        }

        public bool ShowNextDialog(bool setContextToDefault)
        {
            if (_dialogQueue.Count <= 0) return false;

            Dialog dialog = _dialogQueue.Dequeue();
            Debug.Log(dialog.text);
            while (dialog.forwardType == DialogForwardType.IMMEDIATE && _dialogQueue.Count > 0)
            {
                dialog = _dialogQueue.Dequeue();
                Debug.Log(dialog.text);
            }

            if (setContextToDefault) currentContext = DialogContext.NOCONTEXT;

            return true;
        }

        public void SetDialogContext(DialogContext newContext)
        {
            // Why? bukankah dialog context sudah publik -> Niatnya kalau memang ada yang mau diexecute juga kak sekaligus ngeset context
            currentContext = newContext;
            ResetConv();
        }
    }

    public enum DialogContext
    {
        NOCONTEXT,
        DISCREPANCYDIFFERENTNAME,
        DISCREPANCYDIFFERENTGENDER,
        CASUALENTEROBJECTIVE
    }
}