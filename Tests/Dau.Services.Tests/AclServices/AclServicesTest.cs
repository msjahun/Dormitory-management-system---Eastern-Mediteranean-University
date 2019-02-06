using Dau.Services.Security;
using Dau.Core.Configuration.AccessControlList;
using Dau.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
                "[{\"UserRole\":\"ADMINISTRATOR\",\"Area\":\"Admin\",\"Controller\":\"ActivityLog\",\"Action\":\"Log\"}," +
                "{\"UserRole\":\"DORMITORYMANAGER\",\"Area\":\"Admin\",\"Controller\":\"ActivityLog\",\"Action\":\"Type\"}," +
                "{\"UserRole\":\"ADMINISTRATOR\",\"Area\":\"Admin\",\"Controller\":\"API\",\"Action\":\"Settings\"}]";

           var mvcControllers = new List<AclMvcControllerInfo> {
           new AclMvcControllerInfo{
           UserRole="ADMINISTRATOR",
           mvcControllers= new List<MvcControllerInfo>{
               new MvcControllerInfo
               {
                   AreaName="Admin",
                   Name="ActivityLog",
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Log"
                       }
                   }
               },
                  new MvcControllerInfo
               {
                   AreaName="Admin",
                   Name="API",
                   DisplayName=null,
                   
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {isSelected=true,
                       ControllerId="Admin:ActivityLog:Log",
                       DisplayName=null,
                       
                           Name="Settings"
                       }
                   }
               },

           }

           },

              new AclMvcControllerInfo{
           UserRole="DORMITORYMANAGER",
           mvcControllers= new List<MvcControllerInfo>{
               new MvcControllerInfo
               {
                   AreaName="Admin",
                   Name="ActivityLog",
                   Actions = new List<MvcActionInfo>
                   {
                       new MvcActionInfo
                       {
                           Name="Type"
                       }
                   }
               }

           }

           }


           };
            _userRolesService.ParseAccessControlJson(bodyStr).ShouldEqual(mvcControllers);
        }
    }
}
