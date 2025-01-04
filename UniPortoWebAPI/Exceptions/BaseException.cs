﻿using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GraduationProject.UniPortoWebAPI.Exceptions
{

    /// <summary>
    /// Represent the Payment Base Exception type.
    /// </summary>
    [Serializable]
    public class BaseException : Exception
    {
        /// <summary>
        /// Gets or sets the Priority of exception.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseException class.
        /// </summary>
        public BaseException()
        {

        }

        /// <summary>
        ///  Initializes a new instance of the BaseException class.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        public BaseException(string message)
            : base(message)
        {

        }

        /// <summary>
        ///  Initializes a new instance of the BaseException class.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="exception">Inneer exception value.</param>
        public BaseException(string message, Exception exception)
            : base(message, exception)
        {

        }

        /// <summary>
        ///  Initializes a new instance of the BaseException class.
        /// </summary>
        /// <param name="info">Message of the exception.</param>
        /// <param name="context">InnerException value.</param>
        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //// thats because we have extra fields we need to deserialze it .
            if (info != null)
            {
                this.Priority = info.GetString("Priority");
            }
        }

        /// <summary>
        /// This override function responsible for performs a custom serialization.
        /// </summary>
        /// <param name="info">SerializationInfo object.</param>
        /// <param name="context">StreamingContext object.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // this is because we have extra feild we need to serialze it .
            if (info != null)
            {
                info.AddValue("Priority", this.Priority);
            }

            base.GetObjectData(info, context);
        }
    }
}