using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
  public  class FilterBottomService : IFilterBottomService
    {
        public List<FiltersFacilityViewModel> GetFilterBottom()
        {
            List<FiltersFacilityViewModel> modelList = new List<FiltersFacilityViewModel>
            {

                new FiltersFacilityViewModel
            {
                FacilityName = "Availability",
               
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName=" Show only Available rooms",
                        OptionCount=236
                    }
                }
            },

                 new FiltersFacilityViewModel
            {
                FacilityName = "Campaigns",

                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Show Discount Dorms",
                        OptionCount=236
                    }
                }
            },

                      new FiltersFacilityViewModel
            {
                FacilityName = "24 hours reception",

                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="7/24 open reception",
                        OptionCount=236
                    }
                }
            },

                                     new FiltersFacilityViewModel
            {
                FacilityName = "Meals",

                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="3 meals included",
                        OptionCount=236
                    },
                     new FacilityOptions
                    {
                        OptionName="Breakfast included",
                        OptionCount=236
                    }, new FacilityOptions
                    {
                        OptionName="Breakfast & dinner included",
                        OptionCount=236
                    }
                }
            },

                                                                    new FiltersFacilityViewModel
            {
                FacilityName = "In Dorm Facility",

                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Paid sport/fitness",
                        OptionCount=236
                    },
                     new FacilityOptions
                    {
                        OptionName="Free sport/fitness",
                        OptionCount=236
                    }
                }
            },
             new FiltersFacilityViewModel
            {
                FacilityName = "Dorm Facilities",
                FacilityIconUrl = null,
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Drawing room",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="Free Internet",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="Paid Internet",
                        OptionCount=16
                    },

                       new FacilityOptions
                    {
                        OptionName="Free parking area",
                        OptionCount=24
                    },
                    new FacilityOptions
                    {
                        OptionName="Lift",
                        OptionCount=2
                    },
                       new FacilityOptions
                    {
                        OptionName="Security camera system",
                        OptionCount=5
                    },
                       new FacilityOptions
                    {
                        OptionName="Paid laundry",
                        OptionCount=5
                    }
                       ,
                       new FacilityOptions
                    {
                        OptionName="Terrace",
                        OptionCount=5
                    }
                }
            },

 new FiltersFacilityViewModel
            {
                FacilityName = "Campus Area",
                FacilityIconUrl = null,
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Northern Campus",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="Southern Campus",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="Other",
                        OptionCount=16
                    },

                     
                }
            },



           
             new FiltersFacilityViewModel
             {
                 FacilityName = "Facility plan/layout",
                 FacilityIconUrl = null,
                 FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="G/B in seperate blocks",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="G/B in seperate floor",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="Family room",
                        OptionCount=16
                    },


                }
             },

                new FiltersFacilityViewModel
             {
                 FacilityName = "Room features",
                 FacilityIconUrl = null,
                 FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="Balcony",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="TV",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="Common WC",
                        OptionCount=16
                    },
                         new FacilityOptions
                    {
                        OptionName="Common Shower",
                        OptionCount=16
                    },
                        new FacilityOptions
                    {
                        OptionName="In Door Wc",
                        OptionCount=16
                    },
                        
                        new FacilityOptions
                    {
                        OptionName="In Door shower",
                        OptionCount=16
                    },
                          new FacilityOptions
                    {
                        OptionName="In Door kitchen",
                        OptionCount=16
                    },
                            new FacilityOptions
                    {
                        OptionName="Common Kitchen",
                        OptionCount=16
                    },
                              new FacilityOptions
                    {
                        OptionName="Cable Internet",
                        OptionCount=16
                    },
                                new FacilityOptions
                    {
                        OptionName="Wireless Internet",
                        OptionCount=16
                    },
                                  new FacilityOptions
                    {
                        OptionName="Central Cooling",
                        OptionCount=16
                    },
                                               new FacilityOptions
                    {
                        OptionName="Central Heating",
                        OptionCount=16
                    },
                                    new FacilityOptions
                    {
                        OptionName="Split Cooling",
                        OptionCount=16
                    },
                                                   new FacilityOptions
                    {
                        OptionName="Split Heating",
                        OptionCount=16
                    },
                 } },

            new FiltersFacilityViewModel
            {
                FacilityName = "Building Age",
                FacilityIconUrl = null,
                FacilityOptions = new List<FacilityOptions>
                {
                    new FacilityOptions
                    {
                        OptionName="0-10 years",
                        OptionCount=25
                    },

                     new FacilityOptions
                    {
                        OptionName="11-20 years",
                        OptionCount=7
                    },

                      new FacilityOptions
                    {
                        OptionName="21- over years",
                        OptionCount=16
                    }

                     
                }
            }

            };
            return modelList;

        }
    }

    public class FiltersFacilityViewModel
    {
        public string FacilityName { get; set; }
        public string FacilityIconUrl { get; set; }
        public List<FacilityOptions> FacilityOptions { get; set; }

    }

    public class FacilityOptions
    {
        public string OptionName { get; set; }
        public int OptionCount { get; set; }
    }

}
