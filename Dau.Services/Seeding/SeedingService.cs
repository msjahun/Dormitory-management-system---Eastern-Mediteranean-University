using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.SearchResultService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Seeding
{
    public class SeedingService : ISeedingService
    {
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTransRepo;
        private readonly IRepository<FeaturesCategory> _featuresCategoryRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _featuresCategoryTransRepo;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;

        public SeedingService(IRepository<Features> featuresRepo,
            IRepository<FeaturesCategory> featuresCategoryRepo,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepo,
            IRepository<FeaturesTranslation> featuresTransRepo,
            IRepository<Review> reviewRepo,

            IRepository<Dormitory> dormitoryRepo,
            IRepository<DormitoryTranslation> dormitoryTransRepo)
        {
            _featuresRepo = featuresRepo;
            _featuresTransRepo = featuresTransRepo;
            _featuresCategoryRepo = featuresCategoryRepo;
            _featuresCategoryTransRepo = featuresCategoryTransRepo;
            _reviewRepo= reviewRepo;
            _dormitoryRepo = dormitoryRepo;

        }

        public void SeedFeatures()
        {

            int EnglishId = 1;
            int TurkishId = 2;
            List<FeaturesCategory> modelList = new List<FeaturesCategory>
            {


            // new FeaturesCategory
            //{
            //    FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
            //             new FeaturesCategoryTranslation
            //                 {
            //                LanguageId=EnglishId,
            //               CategoryName="Availability",
            //              CategoryDescription ="Feature Description"
            //                  },
            //            new FeaturesCategoryTranslation
            //              {
            //              LanguageId=TurkishId,
            //                CategoryName="AvailabilityTR",
            //               CategoryDescription ="Feature DescriptionTR"
            //                  }

            //         },
            //    Features = new List<Features>
            //    {
            //        new Features
            //        {
            //            IsPublished= true,
            //            FeaturesTranslations = new List<FeaturesTranslation>
            //            {
            //                new FeaturesTranslation
            //                {LanguageId = EnglishId,
            //                    FeatureName = "Show only Available rooms",
            //                    FeatureDescription = "Description"
            //                },

            //                  new FeaturesTranslation
            //                {LanguageId = TurkishId,
            //                    FeatureName = "Show only Available roomsTR",
            //                    FeatureDescription = "DescriptionTR"
            //                }
            //            }
            //        }
            //    }
            //    },

//#new#########################################----

            // new FeaturesCategory
            //{
            //    FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
            //             new FeaturesCategoryTranslation
            //                 {
            //                LanguageId=EnglishId,
            //               CategoryName="Campaigns",
            //              CategoryDescription ="Description campaign"
            //                  },
            //            new FeaturesCategoryTranslation
            //              {
            //              LanguageId=TurkishId,
            //                CategoryName="CampaignsTR",
            //               CategoryDescription ="Description campaignTR"
            //                  }

            //         },
            //    Features = new List<Features>
            //    {
            //        new Features
            //        {
            //            IsPublished= true,
            //            FeaturesTranslations = new List<FeaturesTranslation>
            //            {
            //                new FeaturesTranslation
            //                {LanguageId = EnglishId,
            //                    FeatureName = "Show Discounts",
            //                    FeatureDescription = "Description"
            //                },

            //                  new FeaturesTranslation
            //                {LanguageId = TurkishId,
            //                    FeatureName = "Show DiscountsTR",
            //                    FeatureDescription = "DescriptionTR"
            //                }
            //            }
            //        }
            //    }
            //    },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="24 hours reception",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="24 hours receptionTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "7/24 open reception",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "7/24 open receptionTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }
                }
                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Meals",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="MealsTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "3 meals included",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "3 meals includedTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }, // new feature


                     new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Breakfast included",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Breakfast includedTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }, // new feature
 new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Breakfast & dinner In Dorm facility",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Breakfast & dinner In Dorm facilityTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }// new feature


                    

                }
                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="In Dorm facility",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="In Dorm facilityTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-exercise-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Paid fitness center",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Paid fitness centerTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },
//new feature
                    new Features
                    {
                          IconUrl="/dusk/png/facilities/icons8-exercise-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Free fitness center",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Free fitness centerTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }


                }
                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Dormitory features",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="Dormitory featuresTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Drawing room",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Drawing roomTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below
                     new Features
                    { IconUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Free Internet",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Free InternetTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                      new Features
                    { IconUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Paid Internet",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Paid InternetTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                       new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Free parking area",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Free parking areaTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                        new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Lift",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "LiftTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                         new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Security camera system",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Security camera systemTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                          new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Paid laundry",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Paid laundryTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },// new below

                           new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Terrace",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "TerraceTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }
                }


                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Campus Area",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="Campus AreaTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Northern Campus",
                                FeatureDescription = "Description" },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Northern CampusTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },
                     new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Southern Campus",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Southern CampusTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },
                      new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Other",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "OtherTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }

}
                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Dormitory layout",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="Dormitory layoutTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "G|B in seperate blocks",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "G|B in seperate blocksTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },

                       new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "G|B in separate floor",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "G|B in separate floorTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },

                          new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Family room",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Family roomTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }


                }
                },

//#new#########################################----
             new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Room features",
                          CategoryDescription ="Feature Description"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="Room featuresTR",
                           CategoryDescription ="Feature DescriptionTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Balcony",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "BalconysTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },
                    new Features
                    {IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "TV",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "TVTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },

                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Common WC",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Common WCTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Common Shower",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Common ShowerTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "In door WC",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "In door WCTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-shower-50.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "In door shower",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "In door showerTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "In door kitchen",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "In door kitchenTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    {IconUrl="/dusk/png/facilities/icons8-restaurant-table-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Common kitchen",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Common kitchenTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Cable Internet",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Cable InternetTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-wi-fi-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Wireless Internet",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Wireless InternetTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },

                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-cooling-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {   
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Central cooling",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Central coolingTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    {    IconUrl="/dusk/png/facilities/icons8-cooling-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Central heating",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Central heatingTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-cooling-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Split cooling",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Split coolingTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },


                    new Features
                    { IconUrl="/dusk/png/facilities/icons8-cooling-64.png",
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "Split heating",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "Split heatingTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }




                }
                },

//#new#########################################----
  new FeaturesCategory
            {
                FeaturesCategoryTranslations = new List<FeaturesCategoryTranslation>{
                         new FeaturesCategoryTranslation
                             {
                            LanguageId=EnglishId,
                           CategoryName="Building age",
                          CategoryDescription ="Description campaign"
                              },
                        new FeaturesCategoryTranslation
                          {
                          LanguageId=TurkishId,
                            CategoryName="Building ageTR",
                           CategoryDescription ="Description campaignTR"
                              }

                     },
                Features = new List<Features>
                {
                    new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "0-10 years",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "0-10 yearsTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },
                      new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "11-20 years",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "11-20 yearsTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    },  new Features
                    {
                        IsPublished= true,
                        FeaturesTranslations = new List<FeaturesTranslation>
                        {
                            new FeaturesTranslation
                            {LanguageId = EnglishId,
                                FeatureName = "21 years and over",
                                FeatureDescription = "Description"
                            },

                              new FeaturesTranslation
                            {LanguageId = TurkishId,
                                FeatureName = "21 years and overTR",
                                FeatureDescription = "DescriptionTR"
                            }
                        }
                    }


                }
                }

//#new#########################################----


            };



            foreach (var category in modelList) {
                _featuresCategoryRepo.Insert(category);
            }


        }

        public void SeedDormitoryData()
        {
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;
            var modelList = new List<Dormitory>
            {
                new Dormitory
            {

                NoOfStudents = 214,
                RatingNo = 9.5,
                ReviewNo = 43,
                Location = "North-Campus",
                NoOfNewFacilities = 12,
                NoOfStaff = 32,
                NoOfAwards = 7,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",

                //public string DormitoryType { get; set; }//should be tableLized
                DormitoryLogoUrl = "https://www.kibrisuniversiteleri.org/wp-content/uploads/2016/07/dogu-akdeniz-universitesi-akademik-takvim-2016.png",
                Published = true,
                DisplayOrder = 1,

                GoodToKnowInfo = new GoodToKnow
                {
                    WeekdaysOpeningTime = new OpeningClosingTime
                    {
                        OpeningTime = 8,
                        ClosingTime = 19
                    },
                    WeekendsOpeningTime = new OpeningClosingTime
                    {
                        OpeningTime = 12,
                        ClosingTime = 16
                    },
                    OtherInfosList = new List<GoodToKnowTitleValue>
                    {
                        new GoodToKnowTitleValue
                        {
                            Icon="fas fa-paw",
                            GoodToKnowTitleValueTranslation= new List<GoodToKonwTitleValueTranslation>
                            {
                                new GoodToKonwTitleValueTranslation
                                { LanguageId = _englishLanguageId,
                                    Title="Pets",
                        Value="Pets are not allowed"
                                },
                                new GoodToKonwTitleValueTranslation
                                {LanguageId = _turkishLanguageId,
                                    Title="PetsTR",
                        Value="Pets are not allowedTR"
                                }
                            }

                        }
                    }
                },
                Seo = new Seo
                {
                    MetaKeywords = "Dormitory, Akdeniz, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Akdeniz private Studio",
                    SearchEngineFriendlyPageName = "Akdeniz-private-Studio"
                },

                Rooms = new List<Room>
                {
                    new Room
                    {

                        NoOfStudents =2,


        RoomsQuota =6,
     HasDeposit =true,
     ShowPrice =true,


       Price = 4300,
        PriceOld =5000,
         NoRoomQuota= 2,

       RoomCatalogImage = new List<RoomCatalogImage>
              {
                new RoomCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new RoomCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=4",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=10",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=12",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },
              },
       RoomFeatures = new List<RoomFeatures>
       {
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 1
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 2
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 3
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 4
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 5
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 6
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId =7
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 8
           }

       },
         Seo = new Seo
         {
               MetaKeywords = "Dormitory, alfam, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Akdeniz dormitory",
                    SearchEngineFriendlyPageName = "Double-room"
         },



       Published = true,
        DisplayOrder = 4,
        RoomTranslation = new List<RoomTranslation>
                        {
            new RoomTranslation
            {LanguageId = _englishLanguageId,
                RoomName ="Single room",
                                GenderAllocation ="Girls and boys on seperate floors",
                            BedType ="Super size king bed"
            },
                new RoomTranslation
            {LanguageId = _turkishLanguageId,
                RoomName ="Single roomTR",
                                GenderAllocation ="Girls and boys on seperate floorsTR",
                            BedType ="Super size king bedTR"
            }


    }
}

                },

                CloseLocations = new List<Locationinformation>
                {
                   new Locationinformation
            {
                NameOfLocation="Electrical Engineering dept.",
                Distance="7 mi",
                Duration="6 mins",
                MapSection="https://www.emu.edu.tr/campusmap?design=empty#b21"
            },
             new Locationinformation
            {
                NameOfLocation="Eco supermarket",
                Distance="7 mi",
                Duration="3 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b32"
            },

              new Locationinformation
            {
                NameOfLocation="Koop bank atm machine",
                Distance="12 mi",
                Duration="13 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b87"
            }

                },

                DormitoryFeatures = new List<DormitoryFeatures>
                {
                   new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 1
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 2
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 3
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 4

                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 8
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 9
                   }
                },

                  DormitoryCatalogImage = new List<DormitoryCatalogImage>
              {
                new DormitoryCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new DormitoryCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=4",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=10",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=12",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },
              },

                DormitoryTranslation = new List<DormitoryTranslation>
                {
                    new DormitoryTranslation
                    {
                LocationRemark = "Good location",
                DormitoryName = "Akdeniz private Studio",
                        LanguageId=_englishLanguageId,
                         RatingText = "Very Good",


                Option = "Students",
                OptionValue = "Students are very friendly",
                StandAloneOption = "Has a lobby!",


                DormitoryDescription = "Akdeniz Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    },
                        new DormitoryTranslation
                    {  LocationRemark = "Very Good locationTR",
                DormitoryName = "Alfam YurduTR",
                        LanguageId=_turkishLanguageId,
                         RatingText = "Very goodTR",


                Option = "StudentsTR",
                OptionValue = "Students are very friendlyTR",
                StandAloneOption = "Has good lobby!TR",


                DormitoryDescription = "Turkish-text Akdeniz Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    }

                }


            }
                 ,  new Dormitory
      {

                NoOfStudents = 234,
                RatingNo = 8.4,
                ReviewNo = 12,
                Location = "South-Campus",
                NoOfNewFacilities = 12,
                NoOfStaff = 22,
                NoOfAwards = 5,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",

                //public string DormitoryType { get; set; }//should be tableLized
                DormitoryLogoUrl = "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                Published = true,
                DisplayOrder = 1,

                GoodToKnowInfo = new GoodToKnow
                {
                    WeekdaysOpeningTime = new OpeningClosingTime
                    {
                        OpeningTime = 9,
                        ClosingTime = 18
                    },
                    WeekendsOpeningTime = new OpeningClosingTime
                    {
                        OpeningTime = 11,
                        ClosingTime = 14
                    },
                    OtherInfosList = new List<GoodToKnowTitleValue>
                    {
                        new GoodToKnowTitleValue
                        {
                            Icon="fas fa-paw",
                            GoodToKnowTitleValueTranslation= new List<GoodToKonwTitleValueTranslation>
                            {
                                new GoodToKonwTitleValueTranslation
                                { LanguageId = _englishLanguageId,
                                    Title="Pets",
                        Value="Pets are not allowed"
                                },
                                new GoodToKonwTitleValueTranslation
                                {LanguageId = _turkishLanguageId,
                                    Title="PetsTR",
                        Value="Pets are not allowedTR"
                                }
                            }

                        }
                    }
                },
                Seo = new Seo
                {
                    MetaKeywords = "Dormitory, alfam, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Alfam dormitory",
                    SearchEngineFriendlyPageName = "Alfam-dormitory"
                },

                Rooms = new List<Room>
                {
                    new Room
                    {

                        NoOfStudents =2000,


        RoomsQuota =23,
     HasDeposit =true,
     ShowPrice =true,


       Price = 2300,
        PriceOld =5000,
         NoRoomQuota= 23,

          RoomCatalogImage = new List<RoomCatalogImage>
              {
                new RoomCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new RoomCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=4",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=10",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=12",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },
              },

       RoomFeatures = new List<RoomFeatures>
       {
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 1
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 2
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 3
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 4
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 5
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 6
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId =7
           },
           new RoomFeatures
           {
              RoomId=1,
                   FeaturesId = 8
           }

       },
         Seo = new Seo
         {
               MetaKeywords = "Dormitory, alfam, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Alfam dormitory",
                    SearchEngineFriendlyPageName = "Single-room"
         },



       Published = true,
        DisplayOrder = 4,
        RoomTranslation = new List<RoomTranslation>
                        {
            new RoomTranslation
            {LanguageId = _englishLanguageId,
                RoomName ="Single room",
                                GenderAllocation ="Girls and boys on seperate floors",
                            BedType ="Super size king bed"
            },
                new RoomTranslation
            {LanguageId = _turkishLanguageId,
                RoomName ="Single roomTR",
                                GenderAllocation ="Girls and boys on seperate floorsTR",
                            BedType ="Super size king bedTR"
            }


    }
}

                },

                CloseLocations = new List<Locationinformation>
                {
                   new Locationinformation
            {
                NameOfLocation="Computer Engineering dept.",
                Distance="4 mi",
                Duration="2 mins",
                MapSection="https://www.emu.edu.tr/campusmap?design=empty#b21"
            },
             new Locationinformation
            {
                NameOfLocation="Health center",
                Distance="7 mi",
                Duration="3 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b32"
            },

              new Locationinformation
            {
                NameOfLocation="Koop bank atm machine",
                Distance="12 mi",
                Duration="13 mins"
                , MapSection="https://www.emu.edu.tr/campusmap?design=empty#b87"
            }

                },

                DormitoryFeatures = new List<DormitoryFeatures>
                {
                   new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 1
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 2
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 3
                   },

                    new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 4
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 5
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 6
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 7
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 8
                   },new DormitoryFeatures
                   {DormitoryId =1,
                   FeaturesId = 9
                   }
                },

              DormitoryCatalogImage = new List<DormitoryCatalogImage>
              {
                new DormitoryCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new DormitoryCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=7",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=4",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=8",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=10",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=12",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },
              },



                DormitoryTranslation = new List<DormitoryTranslation>
                {
                    new DormitoryTranslation
                    {
                LocationRemark = "Excellent location",
                DormitoryName = "Alfam Dormitory",
                        LanguageId=_englishLanguageId,
                         RatingText = "Excellent",


                Option = "Staff",
                OptionValue = "Staff are very friendly",
                StandAloneOption = "Has a gym!",


                DormitoryDescription = " Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    },
                        new DormitoryTranslation
                    {  LocationRemark = "Excellent locationTR",
                DormitoryName = "Alfam DormitoryTR",
                        LanguageId=_turkishLanguageId,
                         RatingText = "ExcellentTR",


                Option = "StaffTR",
                OptionValue = "Staff are very friendlyTR",
                StandAloneOption = "Has a gym!TR",


                DormitoryDescription = "Turkish-text Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    }

                }


            }
        };
      



            foreach (var dormitory in modelList)
            {
                _dormitoryRepo.Insert(dormitory);
            }
         


        }


        public void SeedReviews()
        {
            List<Review> reviews = new List<Review>
            {
                new Review
                {
                   DormitoryId =1,
                   Rating = 6.6,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory - Review 1 dormitory 1",
                   UserId = "1e2617d6-b572-4ba9-88ec-d6c89b644fd6"
                },
                 new Review
                {
                   DormitoryId =2,
                   Rating =9.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 2  dormitory 2",
                   UserId = "1e2617d6-b572-4ba9-88ec-d6c89b644fd6"
                },
                  new Review
                {
                   DormitoryId =1,
                   Rating = 7,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 3 dormitory 1",
                   UserId = "2bfc2aba-73aa-45da-a212-b4512c91557a"
                },
                   new Review
                {
                   DormitoryId =2,
                   Rating =8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 4 dormitory 2",
                   UserId ="68c78b20-dd95-4df1-8e10-e16247dd87e6"
                },
                    new Review
                {
                   DormitoryId =1,
                   Rating = 7.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 5 dormitory 1",
                   UserId = "e050a363-7543-47fd-bd76-1eb9adf5bea0"
                },
                     new Review
                {
                   DormitoryId =2,
                   Rating = 8.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 6 dormitory 2",
                   UserId = "e050a363-7543-47fd-bd76-1eb9adf5bea0"
                }

        };

            foreach (var review in reviews)
            {
                _reviewRepo.Insert(review);
            }
        }







    }


}
