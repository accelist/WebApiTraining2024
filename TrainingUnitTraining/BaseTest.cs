﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingUnitTraining
{
    public class BaseTest
    {
        public readonly WebApplicationFactory<Program> _factory;

        public BaseTest()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        public HttpClient GetClient => _factory.CreateClient();
    }
}
