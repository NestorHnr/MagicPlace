﻿using System.Net;

namespace MagicPlace_Web.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsExitoso { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public object Result { get; set; }
    }
}
