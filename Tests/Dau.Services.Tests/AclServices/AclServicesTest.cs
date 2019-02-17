using Dau.Services.Security;
using Dau.Core.Configuration.AccessControlList;
using Dau.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Dau.Services.Tests.AclServices
{
    [TestFixture]
    public class AclServicesTest
    {
        private UserRolesService _userRolesService;

        [SetUp]
        public void SetUp()
        {


           _userRolesService = new UserRolesService(null,null,null,null,null);

        }

    

        [Test]
        public void Parse_Access_Control_Json_Test()
        {
            string bodyStr =
                "[{\"UserRole\":\"ADMINISTRATOR\",\"Area\":\"Admin\",\"Controller\":\"Debug\",\"Action\":\"Log\"}," +
              
                "{\"UserRole\":\"ADMINISTRATOR\",\"Controller\":\"Debug\",\"Action\":\"Log\"}]";

            var mvcControllers = new List<AclMvcControllerInfo> {
           new AclMvcControllerInfo{
           UserRole="ADMINISTRATOR",
           mvcControllers= new List<MvcControllerInfo>{
             
                    new MvcControllerInfo
               {
                   AreaName=null,
                   Name="Debug",
                   DisplayName=null,
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Log",
                           DisplayName=null,
                           ControllerId=":Debug"
                       }
                   }
               },
                      new MvcControllerInfo
               {
                   AreaName="Admin",
                   Name="Debug",
                   DisplayName=null,
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Log",
                           DisplayName=null,
                           ControllerId="Admin:Debug"

                       }
                   }
               }

           }

           }

           
           };


            //  (1 + 1).ShouldEqual(3);
            JsonConvert
                   .SerializeObject(_userRolesService
                   .ParseAccessControlJson(bodyStr))
                   .ShouldEqual(JsonConvert.SerializeObject(mvcControllers));
        }

        [Test]
        public void Parse_Access_Control_Json_With_Area_Public_Test()
        {
            string bodyStr =
                "[{\"UserRole\":\"ADMINISTRATOR\",\"Area\":\"Public\",\"Controller\":\"Debug\",\"Action\":\"Log\"}]";

            var mvcControllers = new List<AclMvcControllerInfo> {
           new AclMvcControllerInfo{
           UserRole="ADMINISTRATOR",
           mvcControllers= new List<MvcControllerInfo>{
               new MvcControllerInfo
               {
                   AreaName=null,
                   Name="Debug",
                   DisplayName=null,
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Log",
                           DisplayName=null,
                           ControllerId=":Debug"
                       }
                   }
               }
           }

           }


           };


            //  (1 + 1).ShouldEqual(3);
            JsonConvert
                   .SerializeObject(_userRolesService
                   .ParseAccessControlJson(bodyStr))
                   .ShouldEqual(JsonConvert.SerializeObject(mvcControllers));
        }




        [Test]
        public void Parse_Access_Control_Json_With_Null_Area_Test()
        {
            string bodyStr =
                "[{\"UserRole\":\"DORMITORYMANAGER\",\"Controller\":\"Debug\",\"Action\":\"Log\"}]";

            var mvcControllers = new List<AclMvcControllerInfo> {
          

              new AclMvcControllerInfo{
           UserRole="DORMITORYMANAGER",
           mvcControllers= new List<MvcControllerInfo>{
               
                    new MvcControllerInfo
               {
                   AreaName=null,
                   Name="Debug",
                   DisplayName=null,
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Log",
                           DisplayName=null,
                           ControllerId=":Debug"
                       }
                   }
               }

           }

           }

           };


            //  (1 + 1).ShouldEqual(3);
            JsonConvert
                   .SerializeObject(_userRolesService
                   .ParseAccessControlJson(bodyStr))
                   .ShouldEqual(JsonConvert.SerializeObject(mvcControllers));
        }

  

    }
}
