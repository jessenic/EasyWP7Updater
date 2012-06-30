using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWP7Updater.Update
{
    /// <summary>
    /// The UpdateMessageEventArguments
    /// </summary>
    class UpdateMessageEventArgs : EventArgs
    {
        /// <summary>
        /// The type of the message
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// The message is an error
            /// </summary>
            Error,
            /// <summary>
            /// The message is a warning
            /// </summary>
            Warning,
            /// <summary>
            /// The message is a information
            /// </summary>
            Info,
            /// <summary>
            /// The message is a logging output
            /// </summary>
            Log
        }

        /// <summary>
        /// The content of the message
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// The message type
        /// </summary>
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
