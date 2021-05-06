using System;

namespace Dialog
{
    [Serializable]
    public class Dialog
    {
        public string text = "";
        public DialogForwardType forwardType = DialogForwardType.STOP;

        public Dialog(string text, DialogForwardType forwardType)
        {
            this.text = text;
            this.forwardType = forwardType;
        }
    }

    public enum DialogForwardType
    {
        STOP,
        IMMEDIATE
    }
}