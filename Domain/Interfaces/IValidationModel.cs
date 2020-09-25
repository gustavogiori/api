using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IValidationModel
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
