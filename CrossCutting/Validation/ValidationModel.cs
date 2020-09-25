using Domain.Interfaces;
using System.Collections.Generic;


namespace CrossCutting.Validation
{
    public class ValidationModel: IValidationModel
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
