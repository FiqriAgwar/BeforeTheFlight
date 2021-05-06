using System.Collections.Generic;
using Dialog;
using UnityEngine;

namespace Person
{
    public class PersonTest : MonoBehaviour
    {
        public bool isAllowed;
        private bool isAccepted;

        // private Dictionary<DocumentType, ICheckableDocument> assignedDocument = new Dictionary<DocumentType, ICheckableDocument>();

        public Dictionary<DialogContext, Queue<Dialog.Dialog>> interrogationDialog =
            new Dictionary<DialogContext, Queue<Dialog.Dialog>>();

        // Start is called before the first frame update
        void Start()
        {
            Queue<Dialog.Dialog> dialogNoContext = new Queue<Dialog.Dialog>(new[]
            {
                new Dialog.Dialog("Hello", DialogForwardType.STOP),
                new Dialog.Dialog("What's your name", DialogForwardType.STOP),
                new Dialog.Dialog("I'm Jorji", DialogForwardType.IMMEDIATE),
                new Dialog.Dialog("I'm from ITB", DialogForwardType.STOP),
            });

            Queue<Dialog.Dialog> dialogWrongName = new Queue<Dialog.Dialog>(new[]
            {
                new Dialog.Dialog("Why's your name different than in passport?", DialogForwardType.STOP),
                new Dialog.Dialog("Oh hmmm", DialogForwardType.IMMEDIATE),
                new Dialog.Dialog("I can explain", DialogForwardType.STOP),
                new Dialog.Dialog("Please do", DialogForwardType.STOP),
            });

            interrogationDialog.Add(DialogContext.NOCONTEXT, dialogNoContext);
            interrogationDialog.Add(DialogContext.DISCREPANCYDIFFERENTNAME, dialogWrongName);
            Debug.Log("Dialog Added");
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void setIsAccepted(bool status)
        {
            this.isAccepted = status;
            Debug.Log(this.isAccepted);
        }
    }

    public enum DocumentType
    {
        KTP,
        TIKET,
        PASPOR
    }
}