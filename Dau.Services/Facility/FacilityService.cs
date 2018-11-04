using Dau.Core.Domain.Facility;
using Dau.Core.Domain.Language;
using Dau.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Facility
{
    public class FacilityService : IFacilityService
    {

        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();

        public void facilities_and_options_data()
        {


            var data = new facility_data();




                    LanguageTable language_Table_EN =  _context .LanguageTable.FirstOrDefault(l => l.LanguageCode == "EN");
                    LanguageTable language_Table_TR =  _context .LanguageTable.FirstOrDefault(l => l.LanguageCode == "TR");

                    FacilityTable facility = new FacilityTable { FacilityIconUrl = data.facility_icon_url };
                     _context .FacilityTable.Add(facility);
                     _context .SaveChanges();




                    //English


                     _context .FacilityTableTranslation.Add(new FacilityTableTranslation
                    {
                        FacilityTableNonTransId= facility.Id,
                        FacilityTitle = data.facility_title_en,
                        LanguageId = language_Table_EN.Id,
                        FacilityDescription = ""
                    });
                     _context .SaveChanges();


                   // Turkish

                     _context .FacilityTableTranslation.Add(new FacilityTableTranslation
                    {
                        FacilityTableNonTransId = facility.Id,
                        FacilityTitle = data.facility_title_tr,
                        LanguageId = language_Table_TR.Id,
                        FacilityDescription = ""
                    });
                     _context .SaveChanges();



                //    down here insert in facility_option, then translate, repeat for all elements
                    foreach (facility_options dataOptions in data.facility_options_list)
                        {

                            FacilityOption facility_Option = new FacilityOption { FacilityId = facility.Id };


                             _context .FacilityOption.Add(facility_Option);
                             _context .SaveChanges();


                             _context .FacilityOptionTranslation.Add(new FacilityOptionTranslation
                            {
                                FacilityOptionNonTransId = facility_Option.Id,
                                LanguageId = language_Table_EN.Id,
                                FacilityOption = dataOptions.facility_option_EN,
                                FacilityOptionDescription = ""

                            });
                             _context .SaveChanges();


                             _context .FacilityOptionTranslation.Add(new FacilityOptionTranslation
                            {
                                FacilityOptionNonTransId = facility_Option.Id,
                                LanguageId = language_Table_TR.Id,
                                FacilityOption = dataOptions.facility_option_TR,
                                FacilityOptionDescription = ""

                            });
                             _context .SaveChanges();

                        }




                

                //here
            



        }

        public List<FacilityTableTranslation> GetFacilities()
        {
            
             
            
            return _context.FacilityTableTranslation.Where(c=> c.LanguageId==1).ToList();
        }


    }

    class facility_data
    {
        

        public String facility_icon_url { get; set; }
        public String facility_title_en { get; set; }
        public String facility_title_tr { get; set; }
        public ArrayList facility_options_list { get; set; }


    }



    public class facility_options
    {
       
        public String facility_option_EN { get; set; }
        public String facility_option_TR { get; set; }
    }

}
