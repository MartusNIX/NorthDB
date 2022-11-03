using System;
using TechTalk.SpecFlow;

namespace NorthDB.Tests
{
    [Binding]
    public class NorthwuindCurdRequestsStepDefinitions
    {
        [When(@"the user adds new data")]
        public void WhenTheUserAddsNewData()
        {
            throw new PendingStepException();
        }

        [Then(@"data is presented in table")]
        public void ThenDataIsPresentedInTable()
        {
            throw new PendingStepException();
        }
    }
}
