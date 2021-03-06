﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class ApplicationUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
    }
}
