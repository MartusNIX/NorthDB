using Microsoft.Extensions.Options;
using NorthDB.Context;
using NorthDB.Models;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace NorthDB.Tests
{
    [Binding]
    public class NorthwuindCurdRequestsStepDefinitions
    {
        private readonly Config config;

        public NorthwuindCurdRequestsStepDefinitions()
        {
            config = new Config();
        }

        [When(@"the user chooses the table")]
        public void WhenTheUserChoosesTheTable()
        {
            //config.Main(options);
        }
    
        [Then(@"the user sees data in the table")]
        public void ThenTheUserSeesDataInTheTable()
        {
            Console.WriteLine("Good");
        }
    }
}
