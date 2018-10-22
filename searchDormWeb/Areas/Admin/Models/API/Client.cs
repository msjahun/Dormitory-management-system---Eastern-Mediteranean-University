using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.API
{
    public class ClientAdd
    {
        [Display(Name = "ClientName",
        Description = "Api client name"), DataType(DataType.Text), MaxLength(256)]
        public string ClientName { get; set; }


        [Display(Name = "ClientId",
        Description = "Api client id"), DataType(DataType.Text), MaxLength(256)]
        public string ClientId { get; set; }

        [Display(Name = "ClientSecret",
            Description = "Api client secret"), DataType(DataType.Text), MaxLength(256)]
        public string ClientSecret { get; set; }

        [Display(Name = "REdirectUrl",
                       Description = "Api redirect url"), DataType(DataType.Text), MaxLength(256)]
        public string REdirectUrl { get; set; }

        [Display(Name = "AccessToikenLifeTime",
                      Description = "Access token lifetime"), MaxLength(256)]
        public int AccessToikenLifeTime { get; set; }

        [Display(Name = "RefreshTokenLifetime",
                      Description = "Refresh token lifetime"), MaxLength(256)]
        public int RefreshTokenLifetime { get; set; }

        [Display(Name = "Enabled",
                       Description = "Check to enable client api")]
        public bool Enabled { get; set; }

    }

    public class ClientEdit
    {


        [Display(Name = "ClientName",
                       Description = "Api client name"), DataType(DataType.Text), MaxLength(256)]
        public string ClientName { get; set; }

        [Display(Name = "ClientId",
                      Description = "Api client id"), DataType(DataType.Text), MaxLength(256)]
        public string ClientId { get; set; }

        [Display(Name = "ClientSecret",
                       Description = "Api client secret"), DataType(DataType.Text), MaxLength(256)]
        public string ClientSecret { get; set; }

        [Display(Name = "REdirectUrl",
                       Description = "Api redirect url"), DataType(DataType.Text), MaxLength(256)]
        public string REdirectUrl { get; set; }

        [Display(Name = "AccessToikenLifeTime",
                       Description = "Access token lifetime"), MaxLength(256)]
        public int AccessToikenLifeTime { get; set; }

        [Display(Name = "RefreshTokenLifetime",
                        Description = "Refresh token lifetime"), MaxLength(256)]
        public int RefreshTokenLifetime { get; set; }

        [Display(Name = "Enabled",
                       Description = "Check to enable client api")]
        public bool Enabled { get; set; }


    }
}
