using ACE.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACE.Full.integration.Tests
{
    [TestClass]
    public class FamilyTests : IntegrationTestBase
    {

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_AddNewFamilyTest()
        {
            MainFamily mainFamily = new MainFamily
            {
                FamilyClan = "Garamosy",
                FamilyName = "Fisho",
                Families = new List<Family>
                {
                    new Family
                    {
                        CreateDate= new DateTime(2000,10,9),
                        Identity="Test_20001"
                    }
                }
            };

            //FamilyControler.AddFamily(mainFamily);//TODO
        }

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_ListMemberOfFamilyTest()
        {

        }

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_AddMembersToFamilyTest()
        {

        }

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_RemoveMembersFromFamilyTest()
        {

        }

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_RemoveWholeFamilyTest()
        {

        }

        [TestCategory("Integration"), TestCategory("SkipWhenLiveUnitTesting"), DataTestMethod]
        public void Family_CreateSubFamilyToMainFamilyTest()
        {

        }

    }
}
