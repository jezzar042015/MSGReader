﻿using System;

namespace DocumentServices.Modules.Readers.MsgReader.Outlook
{
    internal partial class Storage
    {
        /// <summary>
        /// Class used to contain all the flag (follow up) information of a <see cref="Storage.Message"/>.
        /// </summary>
        public sealed class Flag : Storage
        {
            #region Internal enum FlagStatus
            public enum FlagStatus
            {
                /// <summary>
                /// The msg object has been flagged as completed
                /// </summary>
                Complete = 1,

                /// <summary>
                /// The msg object has been flagged and marked as a task
                /// </summary>
                Marked = 2
            }
            #endregion

            #region Properties
            /// <summary>
            /// Returns the flag request text
            /// </summary>
            public string Request
            {
                get { return GetMapiPropertyString(MapiTags.FlagRequest); }
            }

            /// <summary>
            /// Returns the <see cref="FlagStatus">Status</see> of the flag
            /// </summary>
            public FlagStatus? Status
            {
                get { return (FlagStatus) GetMapiPropertyInt32(MapiTags.PR_FLAG_STATUS); }
            }
            #endregion

            #region Constructor
            /// <summary>
            ///   Initializes a new instance of the <see cref="Storage.Flag" /> class.
            /// </summary>
            /// <param name="message"> The message. </param>
            internal Flag(Storage message) : base(message._storage)
            {
                _namedProperties = message._namedProperties;
                GC.SuppressFinalize(message);
                _propHeaderSize = MapiTags.PropertiesStreamHeaderTop;
            }
            #endregion
        }
    }
}