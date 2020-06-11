﻿using Microsoft.AspNetCore.Http;
using System;

namespace Tilbake.Application.ViewModels
{
    public class FileUpLoadViewModel
    {
        public Guid KlientID { get; set; }
        public Guid DocumentCategoryID { get; set; }
        public IFormFile File { get; set; }
    }
}