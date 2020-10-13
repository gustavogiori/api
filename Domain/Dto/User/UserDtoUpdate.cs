using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dto.User
{
    public class UserDtoUpdate : UserDtoCrud
    {
        public int Id { get; set; }
    }
}
