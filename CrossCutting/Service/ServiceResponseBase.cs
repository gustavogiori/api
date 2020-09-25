using CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Service
{
    public abstract class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            this.Exception = null;
            this.ValidationModel = new ValidationModel();
        }

        /// <summary>
        /// Save the exception thrown so that consumers can read it
        /// </summary>
        public Exception Exception { get; set; }

        public ValidationModel ValidationModel { get; set; }
    }
}