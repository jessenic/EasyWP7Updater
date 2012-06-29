using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Update
{
    class UpdateMessageEventArgs : EventArgs
    {
        public enum MessageType
        {
            Error,
            Warning,
            Info,
            Log
        }

        public string Message { get; private set; }
        public MessageType Type { get; private set; }

        public UpdateMessageEventArgs(string message, MessageType type)
        {
            Type = type;
            Message = message;
        }

        public UpdateMessageEventArgs(string message)
            : this(message, MessageType.Info)
        { }
    }
}
