using Microsoft.Extensions.Options;
using NorthDB.Context;
using NorthDB.Models;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using NorthDB.Tests;

namespace NorthDB.Tests
{
    [Binding]
    public class NorthStepDefinitions
    {
        //private readonly Config config;

        public NorthStepDefinitions()
        {
            //config = new Config();
        }

        [When(@"the user chooses the table")]
        public static void WhenTheUserChoosesTheTable()
        {
            
        }

        [Then(@"the user sees data in the table")]
        public static void ThenTheUserSeesDataInTheTable()
        {
            
        }
    }
}
