using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.EmuMap;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Domain.SearchResultService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<SemesterPeriod> _semesterPeriodRepository;
        private readonly IRepository<MapSection> _mapSectionRepo;
        private readonly IRepository<MapSectionCategory> _mapSectionCategoryRepo;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<PaymentStatus> _paymentStatusRepository;
        private readonly IRepository<BookingStatus> _bookingStatusRepository;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;

        public SeedingService(IRepository<Features> featuresRepo,
            IRepository<FeaturesCategory> featuresCategoryRepo,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepo,
            IRepository<FeaturesTranslation> featuresTransRepo,
            IRepository<Review> reviewRepo,
            IRepository<Room> roomRepo,
            IRepository<DormitoryType> dormitoryTypeRepo,
            IRepository<DormitoryBlock> dormitoryBlockRepo,
            IRepository<Dormitory> dormitoryRepo,
            IRepository<DormitoryTranslation> dormitoryTransRepo,
            IRepository<Booking> bookingRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            IRepository<BookingStatus> bookingStatusRepository,
            IRepository<Cart> cartRepository,
            IRepository<SemesterPeriod> semesterPeriodRepository,
            UserManager<User> userManager,
            IRepository<MapSection> mapSectionRepo,
            IRepository<MapSectionCategory> mapSectionCategoryRepo
            )
        {

            _roomRepo= roomRepo;
            _dormitoryTypeRepo= dormitoryTypeRepo;
            _dormitoryBlockRepo= dormitoryBlockRepo;
            _bookingRepository = bookingRepository;
            _paymentStatusRepository= paymentStatusRepository;
            _bookingStatusRepository= bookingStatusRepository;
            _featuresRepo = featuresRepo;
            _featuresTransRepo = featuresTransRepo;
            _featuresCategoryRepo = featuresCategoryRepo;
            _featuresCategoryTransRepo = featuresCategoryTransRepo;
            _reviewRepo= reviewRepo;
            _dormitoryRepo = dormitoryRepo;
            _userManager = userManager;
            _cartRepository= cartRepository;
            _semesterPeriodRepository= semesterPeriodRepository;
            _mapSectionRepo= mapSectionRepo;
            _mapSectionCategoryRepo= mapSectionCategoryRepo;

        }

        //seed dormitoryType and dormitory blocks 
        //seed rooms seperately
        //seed dormitories seperately

        public void SeedFeatures()
        {
            //seed Semester periods
            int EnglishId = 1;
            int TurkishId = 2;

            var SemesterPeriodsList = new List<SemesterPeriod>
            {
                new SemesterPeriod
                {
                 IsPublished= true,
                 DisplayOrder = 0,
                 IsCurrentSemester = true,
                 IsNextSemester = false,
                 StartDate =DateTime.Now,
                 EndDate = DateTime.Now.AddMonths(3),
                 SemesterPeriodTranslations = new List<SemesterPeriodTranslation>
                 {
                     new SemesterPeriodTranslation
                     {
                         LanguageId = EnglishId,
                         SemesterPeriodName = "1 Semester - Fall 2019"
                     },
                      new SemesterPeriodTranslation
                     {
                         LanguageId = TurkishId,
                         SemesterPeriodName = "1 Semester - Fall 2019TR"
                     }

                 }

                },

                 new SemesterPeriod
                {
                 IsPublished= true,
                 DisplayOrder = 0,
                 IsCurrentSemester = false,
                 IsNextSemester = true,
                 StartDate =DateTime.Now,
                 EndDate = DateTime.Now.AddMonths(3),
                 SemesterPeriodTranslations = new List<SemesterPeriodTranslation>
                 {
                     new SemesterPeriodTranslation
                     {
                         LanguageId = EnglishId,
                         SemesterPeriodName = "3 months - Summer 2019"
                     },
                      new SemesterPeriodTranslation
                     {
                         LanguageId = TurkishId,
                         SemesterPeriodName = "3 months - Summer 2019TR"
                     }

                 }

                },

                   new SemesterPeriod
                {
                 IsPublished= true,
                 DisplayOrder = 0,
                 IsCurrentSemester = false,
                 IsNextSemester = false,
                 StartDate =DateTime.Now,
                 EndDate = DateTime.Now.AddMonths(3),
                 SemesterPeriodTranslations = new List<SemesterPeriodTranslation>
                 {
                     new SemesterPeriodTranslation
                     {
                         LanguageId = EnglishId,
                         SemesterPeriodName = "1 year - Fall 2019 to Spring 2020"
                     },
                      new SemesterPeriodTranslation
                     {
                         LanguageId = TurkishId,
                         SemesterPeriodName = "1 year - Fall 2019 to Spring 2020TR"
                     }

                 }

                },


                    new SemesterPeriod
                {
                 IsPublished= true,
                 DisplayOrder = 0,
                 IsCurrentSemester = false,
                 IsNextSemester = false,
                 StartDate =DateTime.Now,
                 EndDate = DateTime.Now.AddMonths(3),
                 SemesterPeriodTranslations = new List<SemesterPeriodTranslation>
                 {
                     new SemesterPeriodTranslation
                     {
                         LanguageId = EnglishId,
                         SemesterPeriodName = "2 years - Fall 2019 to next fall 2021"
                     },
                      new SemesterPeriodTranslation
                     {
                         LanguageId = TurkishId,
                         SemesterPeriodName = "2 years - Fall 2019 to next fall 2021TR"
                     }

                 }

                }

            };

            foreach( var semesterPeriod in SemesterPeriodsList)
            {
                _semesterPeriodRepository.Insert(semesterPeriod);
            }

            List<FeaturesCategory> modelList = new List<FeaturesCategory>
            {



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
                        HitCount=3,
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
                    HitCount= 2,
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

        public void SeedDormitoryType()
        {
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;

            var DormitoryTypeList = new List<DormitoryType>
            {
                new DormitoryType
                {
                    IsPublished = true,
       CreatedDate= DateTime.Now,
       
         DormitoryTypeTranslation = new List<DormitoryTypeTranslation>
         {
             new DormitoryTypeTranslation
             {
                 LanguageId = _englishLanguageId,
                Title ="School dormitory",
                 Description ="School dormitory description"
                },

             new DormitoryTypeTranslation
             {
                 LanguageId = _turkishLanguageId,
                Title ="School dormitoryTR",
                 Description ="School dormitory descriptionTR"
                }
            }

           },
                         new DormitoryType
                {
                    IsPublished = true,
       CreatedDate= DateTime.Now,

         DormitoryTypeTranslation = new List<DormitoryTypeTranslation>
         {
             new DormitoryTypeTranslation
             {
                 LanguageId = _englishLanguageId,
                Title ="Private Dormitory",
                 Description ="Private Dormitory description"
                },

             new DormitoryTypeTranslation
             {
                 LanguageId = _turkishLanguageId,
                Title ="Private DormitoryTR",
                 Description ="Private Dormitory descriptionTR"
                }
            }

           }


            };

            foreach(var DormitoryType in DormitoryTypeList)
            {
                _dormitoryTypeRepo.Insert(DormitoryType);
            }


        }

        public void SeedDormitoryData()
        {
            //seedDormitoryType 
            //DormitoryBlock

            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;
            var modelList = new List<Dormitory>
            {
                new Dormitory
            {MapSectionId=5,
                    DormitoryTypeId = 1,
                NoOfStudents = 214,
                RatingNo = 9.5,
                ReviewNo = 43,
                BookingLimit = 1,
                LocationOnCampus=1,
               
                NoOfNewFacilities = 12,
                NoOfStaff = 32,
                NoOfAwards = 7,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                SKU = "434lkjsdf",
                //public string DormitoryType { get; set; }//should be tableLized
                DormitoryLogoUrl = "https://www.kibrisuniversiteleri.org/wp-content/uploads/2016/07/dogu-akdeniz-universitesi-akademik-takvim-2016.png",
                Published = true,
                 WeekendsOpeningTime = DateTime.Now,
                        WeekendsClosingTime = DateTime.Now.AddHours(3),
                         WeekdaysOpeningTime = DateTime.Now,
                        WeekdaysClosingTime = DateTime.Now.AddHours(2),

      
                Seo = new Seo
                {
                    MetaKeywords = "Dormitory, Akdeniz, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Akdeniz private Studio",
                    SearchEngineFriendlyPageName = "Akdeniz-private-Studio"
                },

            

                CloseLocations = new List<Locationinformation>
                {
                   new Locationinformation
            {
                NameOfLocation="Electrical Engineering dept.",
                Distance="7 mi",
                Duration="6 mins",
                MapSection="b21"
            },
             new Locationinformation
            {
                NameOfLocation="Eco supermarket",
                Distance="7 mi",
                Duration="3 mins"
                , MapSection="b32"
            },

              new Locationinformation
            {
                NameOfLocation="Koop bank atm machine",
                Distance="12 mi",
                Duration="13 mins"
                , MapSection="b87"
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
                  ImageUrl=  "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new DormitoryCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

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
                DormitoryName = "Akdeniz private Studio",
                        LanguageId=_englishLanguageId,
                         RatingText = "Very Good",


              


                DormitoryDescription = "Akdeniz Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    },
                        new DormitoryTranslation
                    {  
                DormitoryName = "Alfam YurduTR",
                        LanguageId=_turkishLanguageId,
                         RatingText = "Very goodTR",


            


                DormitoryDescription = "Turkish-text Akdeniz Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    }

                }


            }
                 ,  new Dormitory
      {
                      DormitoryTypeId = 2,
                      MapSectionId=3,
                NoOfStudents = 234,
                RatingNo = 8.4,
                ReviewNo = 12,
              BookingLimit=1,
              LocationOnCampus =1,
                NoOfNewFacilities = 12,
                NoOfStaff = 22,
                NoOfAwards = 5,
                DormitoryStreetAddress = "Wolfgang Amadeus Mozart Street",
                 SKU = "rerjsdf",
                //public string DormitoryType { get; set; }//should be tableLized
                DormitoryLogoUrl = "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
                Published = true,
                   WeekendsOpeningTime = DateTime.Now,
                        WeekendsClosingTime = DateTime.Now.AddHours(3),
                         WeekdaysOpeningTime = DateTime.Now,
                        WeekdaysClosingTime = DateTime.Now.AddHours(2),

                Seo = new Seo
                {
                    MetaKeywords = "Dormitory, alfam, emu",
                    MetaDescription = "Dormitory description",
                    MetaTitle = "Alfam dormitory",
                    SearchEngineFriendlyPageName = "Alfam-dormitory"
                },

            

                CloseLocations = new List<Locationinformation>
                {
                   new Locationinformation
            {
                NameOfLocation="Computer Engineering dept.",
                Distance="4 mi",
                Duration="2 mins",
                MapSection="b21"
            },
             new Locationinformation
            {
                NameOfLocation="Health center",
                Distance="7 mi",
                Duration="3 mins"
                , MapSection="b32"
            },

              new Locationinformation
            {
                NameOfLocation="Koop bank atm machine",
                Distance="12 mi",
                Duration="13 mins"
                , MapSection="b87"
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
                  ImageUrl=  "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new DormitoryCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new DormitoryCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new DormitoryCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

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
               
                DormitoryName = "Alfam Dormitory",
                        LanguageId=_englishLanguageId,
                         RatingText = "Excellent",




                DormitoryDescription = " Located within the EMU Campus, Alfam Dormitories is the nearest dormitory to the Departments. Spread over 35 acres of land Alfam provides a service based on the needs of the Students." +

          " <br><br> Our Dormitory is protected by CCTV in all its buildings and corridors as well as 24 hour attendance of Secuirty members. All our rooms are cleaned by our cleaning staff twice a week, the common areas daily and the bed linen changed every week." +

           "<br><br>with its 12 different types of rooms, Alfam Dormitories offers a choice for all types of budgets and needs. All our students enjoy the benefit of 4 Mbit unlimited and free internet and no deposit." +

          "<br><br> Alfam Dormitories also includes Fitness Center, Cafe, Restaurant, Stationerer in its capacity. Alfam Dormitories with its friendly personel has been providing a service for students with 20 years experience always continuing to strive for the best."


                    },
                        new DormitoryTranslation
                    {  
                DormitoryName = "Alfam DormitoryTR",
                        LanguageId=_turkishLanguageId,
                         RatingText = "ExcellentTR",




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

        public void seedDormitoryBlocks()
        {
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;

            var DormitoryBlockList = new List<DormitoryBlock>
            {
                new DormitoryBlock
                {
                  Published = true,
                  DisplayOrder= 0,


                  DormitoryId= 1,
                  DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = "A block",
                         Description ="The first block in dormitory"

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = "A blockTR",
                         Description ="The first block in dormitoryTR"

                         }

                    }
                },
                new DormitoryBlock
                {
                  Published = true,
                  DisplayOrder= 0,


                  DormitoryId= 1,
                  DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = "A block",
                         Description ="The first block in dormitory"

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = "A blockTR",
                         Description ="The first block in dormitoryTR"

                         }

                    }
                },
                new DormitoryBlock
                {
                  Published = true,
                  DisplayOrder= 0,


                  DormitoryId= 1,
                  DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = "Alfam Vista block",
                         Description ="The Best block in dormitory"

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = "Alfam Vista blockTR",
                         Description ="The Best block in dormitoryTR"

                         }

                    }
                },
                new DormitoryBlock
                {
                  Published = true,
                  DisplayOrder= 0,


                  DormitoryId= 2,
                  DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = "A block",
                         Description ="The first block in dormitory"

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = "A blockTR",
                         Description ="The first block in dormitoryTR"

                         }

                    }
                },
                 new DormitoryBlock
                {
                  Published = true,
                  DisplayOrder= 0,


                  DormitoryId= 2,
                  DormitoryBlockTranslations = new List<DormitoryBlockTranslation>
                  {
                      new DormitoryBlockTranslation{
                          LanguageId = _englishLanguageId,
                          Name = "b block",
                         Description ="The b block in dormitory"

                         },

                       new DormitoryBlockTranslation{
                          LanguageId =_turkishLanguageId,
                          Name = "bblockTR",
                         Description ="The first b in dormitoryTR"

                         }

                    }
                }
            };

            foreach(var dormitoryBlock in DormitoryBlockList)
            {
                _dormitoryBlockRepo.Insert(dormitoryBlock);
            }

        }

        public void SeedRoomData()
        {
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;

         
          
            var _domritoryId_1 = (from dorm in _dormitoryRepo.List().ToList() where dorm.DormitoryTypeId == 1 select new { dorm.Id }).FirstOrDefault().Id;
            var _domritoryId_2 = (from dorm in _dormitoryRepo.List().ToList() where dorm.DormitoryTypeId == 2 select new { dorm.Id }).FirstOrDefault().Id;
            var RoomsList = new List<Room>
            {
              
                    new Room
                    {

                        NoOfStudents =2000,
DormitoryId = _domritoryId_1,
  PaymentPerSemesterNotYear= true,
DormitoryBlockId=1,
     TaxAmount =10,
      BookingFee =15,
       SKU = "Er90fd",
     HasDeposit =true,
     ShowPrice =true,
     RoomSize = 43.3,
   
       Price = 2300,
        PriceOld =5000,
         NoRoomQuota= 23,
          PercentageOff = 30, //from database
                                    DealEndTime = DateTime.Now.AddDays(3), //change this to come from db
                                    DisplayNoRoomsLeft = true,
                                    DisplayDeal = true,

          RoomCatalogImage = new List<RoomCatalogImage>
              {
                new RoomCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new RoomCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

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
},
                
                    new Room
                    {

                        NoOfStudents =2,
        TaxAmount =23,
      BookingFee =0,
       DormitoryId = _domritoryId_1,
DormitoryBlockId=2,
        SKU = "5g0fd",
     HasDeposit =true,
     ShowPrice =true,
       DisplayNoRoomsLeft = true,
                                    DisplayDeal = false,
      RoomSize = 15,
      PaymentPerSemesterNotYear= false,
       Price = 4300,
        PriceOld =5000,

         NoRoomQuota= 2,

       RoomCatalogImage = new List<RoomCatalogImage>
              {
                new RoomCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new RoomCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

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
},
                       new Room
                    {

                        NoOfStudents =4,
                             TaxAmount =50,
      BookingFee =0,
DormitoryId =  _domritoryId_2,
DormitoryBlockId = 1,
  PaymentPerSemesterNotYear= true,
       
     HasDeposit =true,
     ShowPrice =true,
      RoomSize = 23.3,
    SKU = "ttdfg4",
       Price = 4300,
        PriceOld =5000,
         NoRoomQuota= 2,
          PercentageOff = 20, //from database
                                    DealEndTime = DateTime.Now.AddDays(6), //change this to come from db
                                    DisplayNoRoomsLeft = false,
                                    DisplayDeal = true,
       RoomCatalogImage = new List<RoomCatalogImage>
              {
                new RoomCatalogImage
                {
                    CatalogImage = new CatalogImage
                    {
                  ImageUrl=  "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
    CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                new RoomCatalogImage
                {
                    CatalogImage=  new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",
                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                   new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {

                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },

                      new RoomCatalogImage
                {
                    CatalogImage= new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                         new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                            new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

                       CreatedDate =DateTime.Now,
                         Published=true,
                         DisplayOrder=0
                     }
                },


                               new RoomCatalogImage
                {
                    CatalogImage=new CatalogImage
                    {
                   ImageUrl= "/Files/Images/RoomImages/S%C3%9C%C4%B0T_1.jpg",

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
                RoomName ="Quadruple room",
                                GenderAllocation ="Girls and boys on seperate floors",
                            BedType ="Super size king bed"
            },
                new RoomTranslation
            {LanguageId = _turkishLanguageId,
                RoomName ="Quadruple roomTR",
                                GenderAllocation ="Girls and boys on seperate floorsTR",
                            BedType ="Super size king bedTR"
            }


    }
}


            };

            foreach(var room in RoomsList)
            {
                _roomRepo.Insert(room);
            }
        }


        public void SeedReviews()
        {
            //get user ids dynamicaly when seeding the reviews
            var UsersList = _userManager.Users;

            var user1Id = from user in UsersList.ToList() where user.UserName == "msjahun@live.com" select new { user.Id };
            var user2Id = from user in UsersList.ToList() where user.UserName == "Chivy1221@gmail.com" select new { user.Id };
            var user3Id = from user in UsersList.ToList() where user.UserName == "Abdullahiismailabubakar@gmail.com" select new { user.Id };
            var user4Id = from user in UsersList.ToList() where user.UserName == "kamaluddeen02@gmail.com" select new { user.Id };

            List<Review> reviews = new List<Review>
            {
                new Review
                {
                   DormitoryId =1,
                   Rating = 6.6,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory - Review 1 dormitory 1",
                   UserId = user1Id.FirstOrDefault().Id
                },
                 new Review
                {
                   DormitoryId =2,
                   Rating =9.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 2  dormitory 2",
                   UserId = user1Id.FirstOrDefault().Id
                },
                  new Review
                {
                   DormitoryId =1,
                   Rating = 7,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 3 dormitory 1",
                   UserId = user3Id.FirstOrDefault().Id
                },
                   new Review
                {
                   DormitoryId =2,
                   Rating =8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 4 dormitory 2",
                   UserId =user2Id.FirstOrDefault().Id
                },
                    new Review
                {
                   DormitoryId =1,
                   Rating = 7.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 5 dormitory 1",
                   UserId = user2Id.FirstOrDefault().Id
                },
                     new Review
                {
                   DormitoryId =2,
                   Rating = 8.8,
                   IsApproved= true,
                   CreatedOn = DateTime.Now,
                   Message = "I love this dormitory Review 6 dormitory 2",
                   UserId = user3Id.FirstOrDefault().Id
                }

        };

            foreach (var review in reviews)
            {
                _reviewRepo.Insert(review);
            }
        }

        public void SeedBookings()
        {
            var EnglishLangId = 1;
            var TurkishLangId = 2;
               //seed payment status
               var paymentStatusList = new List<PaymentStatus>
            {
                new PaymentStatus
                {
                         CreatedDate = DateTime.Now,
                         PaymentStatusTranslations = new List<PaymentStatusTranslation>{
                             new PaymentStatusTranslation
                             {
                                 LanguageId = EnglishLangId,
                                 PaymentStatus = "Payment complete"
                             },

                              new PaymentStatusTranslation
                             {
                                 LanguageId = TurkishLangId,
                                 PaymentStatus = "Payment completeTR"
                             }

                                 }


                 },

                new PaymentStatus
                {
                         CreatedDate = DateTime.Now,
                         PaymentStatusTranslations = new List<PaymentStatusTranslation>{
                             new PaymentStatusTranslation
                             {
                                 LanguageId = EnglishLangId,
                                 PaymentStatus = "Pending"
                             },

                              new PaymentStatusTranslation
                             {
                                 LanguageId = TurkishLangId,
                                 PaymentStatus = "PendingTR"
                             }

                                 }


                 },

                new PaymentStatus
                {
                         CreatedDate = DateTime.Now,
                         PaymentStatusTranslations = new List<PaymentStatusTranslation>{
                             new PaymentStatusTranslation
                             {
                                 LanguageId = EnglishLangId,
                                 PaymentStatus = "Not paid"
                             },

                              new PaymentStatusTranslation
                             {
                                 LanguageId = TurkishLangId,
                                 PaymentStatus = "Not paidTR"
                             }

                                 }


                 }

               };
            foreach(var paymentstatus in paymentStatusList)
            {
                _paymentStatusRepository.Insert(paymentstatus);
            }

            //seed booking status
            var bookingStatusList = new List<BookingStatus>
            {
                new BookingStatus
                {
                    CreatedDate= DateTime.Now,
                     BookingStatusTranslations = new List<BookingStatusTranslation>
                     {
                        new BookingStatusTranslation
                        {
                            LanguageId = EnglishLangId,
                            BookingStatus = "Completed"
                        },
                         new BookingStatusTranslation
                        {
                            LanguageId = TurkishLangId,
                            BookingStatus = "CompletedTR"
                        }
                     }
                },

                 new BookingStatus
                {
                    CreatedDate= DateTime.Now,
                     BookingStatusTranslations = new List<BookingStatusTranslation>
                     {
                        new BookingStatusTranslation
                        {
                            LanguageId = EnglishLangId,
                            BookingStatus = "Pending"
                        },
                         new BookingStatusTranslation
                        {
                            LanguageId = TurkishLangId,
                            BookingStatus = "PendingTR"
                        }
                     }
                },

                  new BookingStatus
                {
                    CreatedDate= DateTime.Now,
                     BookingStatusTranslations = new List<BookingStatusTranslation>
                     {
                        new BookingStatusTranslation
                        {
                            LanguageId = EnglishLangId,
                            BookingStatus = "Cancelled"
                        },
                         new BookingStatusTranslation
                        {
                            LanguageId = TurkishLangId,
                            BookingStatus = "CancelledTR"
                        }
                     }
                }




            };

            foreach(var bookingstatus in bookingStatusList)
            {
                _bookingStatusRepository.Insert(bookingstatus);
            }

            //seed Users vs dormitory room booking data
            var UsersList = _userManager.Users;

            var user1Id = from user in UsersList.ToList() where user.UserName == "msjahun@live.com" select new { user.Id };
            var user2Id = from user in UsersList.ToList() where user.UserName == "Chivy1221@gmail.com" select new { user.Id };
            var user3Id = from user in UsersList.ToList() where user.UserName == "Abdullahiismailabubakar@gmail.com" select new { user.Id };
            var user4Id = from user in UsersList.ToList() where user.UserName == "kamaluddeen02@gmail.com" select new { user.Id };

            var bookings = new List<Booking>
            {
                new Booking
                { BookingStatusId =1,
                PaymentStatusId = 2,
                UserId = user1Id.FirstOrDefault().Id,
                CustomerIpAddress = "23.21.203.43", 
                BookingOrderSubtotal = 2300,
                BookingFee = 25,
                BookingTotal = 2325,
                CreatedOn =DateTime.Now,
                RoomId =2
                },

                new Booking
                { BookingStatusId =2,
                PaymentStatusId = 2,
                UserId = user2Id.FirstOrDefault().Id,
                CustomerIpAddress = "53.21.203.43",
                BookingOrderSubtotal = 6300,
                BookingFee = 25,
                BookingTotal = 6325,
                CreatedOn =DateTime.Now,
                RoomId =2
                },

                new Booking
                { BookingStatusId =1,
                PaymentStatusId = 1,
                UserId = user3Id.FirstOrDefault().Id,
                CustomerIpAddress = "23.21.203.43",
                BookingOrderSubtotal = 4300,
                BookingFee = 25,
                BookingTotal = 4325,
                CreatedOn =DateTime.Now,
                RoomId =2
                },

                new Booking
                { BookingStatusId =2,
                PaymentStatusId = 1,
                UserId = user4Id.FirstOrDefault().Id,
                CustomerIpAddress = "25.21.203.43",
                BookingOrderSubtotal = 5300,
                BookingFee = 25,
                BookingTotal = 5325,
                CreatedOn =DateTime.Now,
                RoomId =1
                }
            };

            foreach(var booking in bookings)
            {
                _bookingRepository.Insert(booking);
            }

        }

        public void SeedCartItems()
        {
            //seed Users and cart items
            var UsersList = _userManager.Users;

            var user1Id = from user in UsersList.ToList() where user.UserName == "msjahun@live.com" select new { user.Id };
            var user2Id = from user in UsersList.ToList() where user.UserName == "Chivy1221@gmail.com" select new { user.Id };
            var user3Id = from user in UsersList.ToList() where user.UserName == "Abdullahiismailabubakar@gmail.com" select new { user.Id };
            var user4Id = from user in UsersList.ToList() where user.UserName == "kamaluddeen02@gmail.com" select new { user.Id };

            var Carts = new List<Cart>
            {
                new Cart
                { RoomId=1,
                    SemesterPeriodId = 1,
                    UserId = user1Id.FirstOrDefault().Id
                },

                  new Cart
                { RoomId=2,
                    SemesterPeriodId = 2,
                    UserId = user2Id.FirstOrDefault().Id
                }

                  


            };

            foreach(var cart in Carts)
            {
                _cartRepository.Insert(cart);
            }

        }


        public void SeedEMUMapLocations()
        {
            //seed categories first, then get their ids, use their ids when Inserting map sections
            // var category1Id= _mapSectionCategoryRepo.Insert();
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;
         var Restaurants=   _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
              CreatedDate =DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Cafe, Cafeteria and restaurants",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Cafe, Cafeteria and restaurantsTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });


            var Dormitories = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Dormitories and accomodations",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Dormitories and accomodationsTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

            var BanksAndAtms = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Banks and Atms",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Banks and AtmsTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

            var OfficesAndFacilties = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Officies and facilities",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Officies and facilitiesTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });


            var SchoolsAndFaculties = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Schools and faculties",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Schools and facultiesTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });


            var Departments = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Departments",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="DepartmentsTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });


            var Classes = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Classes",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="ClassesTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

            var OtherImportantPlaces = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Other important places on campus",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Other important places on campusTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

               var ActivityCentersAndHalls = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Activity centers and halls",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Activity centers and hallsTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

            var StreetAddresses = _mapSectionCategoryRepo.Insert(new MapSectionCategory
            {
                CreatedDate = DateTime.Now,
                MapSectionCategoryTranslation = new List<MapSectionCategoryTranslation>
                {
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Streets and addresses",
                       CategoryDescription ="",
                       LanguageId=_englishLanguageId,

                    },
                    new MapSectionCategoryTranslation
                    {
                       CategoryName ="Streets and addressesTR",
                       CategoryDescription ="",
                       LanguageId=_turkishLanguageId,

                    }

                }
            });

            //seed mapsections with categoryid

            var mapSections = new List<MapSection>
            {


new MapSection {BuildingId=10,Latitude =35.140949716452,Longitude =33.9125800085983,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Student Activity Center Cafeteria SODEXHO"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Öğrenci Aktivite Merkezi Kafeteryası SODEXHO"}}},
new MapSection {BuildingId=11,Latitude =35.1404875896339,Longitude =33.9122094490738,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Education Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Eğitim Fakültesi Kafeteryası"}}},
new MapSection {BuildingId=47,Latitude =35.1415089096326,Longitude =33.9135431251659,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Basket Restaurant"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Basket Restaurant"}}},
new MapSection {BuildingId=51,Latitude =35.1434544008847,Longitude =33.909412231877,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Table d\"Hote Restaurant"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Tabldot Restaurant"}}},
new MapSection {BuildingId=13,Latitude =35.1396581697531,Longitude =33.9108724576721,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Sabancı Dormitory Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sabancı Yurdu Kafeteryası"}}},
new MapSection {BuildingId=14,Latitude =35.141042782992,Longitude =33.910537390213,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Business and Economics Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İşletme ve Ekonomi Fakültesi Kafeteryası"}}},
new MapSection {BuildingId=7,Latitude =35.1420638020821,Longitude =33.9109696269836,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="IntBrunch Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="IntBrunch Kafeteria"}}},
new MapSection {BuildingId=16,Latitude =35.1431660098485,Longitude =33.9123346785736,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Mechanical Engineering Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Makine Mühendisliği Kafeteryası"}}},
new MapSection {BuildingId=42,Latitude =35.144368479463,Longitude =33.9121821779098,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Merkez Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Merkez Kafeterya"}}},
new MapSection {BuildingId=17,Latitude =35.1452333531677,Longitude =33.9091810584066,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Civil Engineering Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İnşaat Mühendisliği Kafeteryası"}}},
new MapSection {BuildingId=4,Latitude =35.144303974056,Longitude =33.9091735079346,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Law Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Hukuk Fakültesi Kafeteryası"}}},
new MapSection {BuildingId=6,Latitude =35.143427956637,Longitude =33.912408678001,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Media Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Medya Kafe"}}},
new MapSection {BuildingId=18,Latitude =35.1407809430946,Longitude =33.9044240932541,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Foreign Languages and English Preparatory School Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Yabancı Diller ve İngilizce Hazırlık Okulu Kafeteryası"}}},
new MapSection {BuildingId=20,Latitude =35.1420148092541,Longitude =33.9130902711639,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="SCT Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="BTYO Kantini"}}},
new MapSection {BuildingId=7,Latitude =35.142185716119,Longitude =33.9108550932541,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Sandra Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sandra Kafeterya"}}},
new MapSection {BuildingId=34,Latitude =35.1438935062738,Longitude =33.9116695681229,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Tourism Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Turizm Fakültesi Kantini"}}},
new MapSection {BuildingId=8,Latitude =35.1456630374062,Longitude =33.9095415337296,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Architecture Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mimarlık Fakültesi Kafeteryası"}}},
new MapSection {BuildingId=53,Latitude =35.1443288013172,Longitude =33.9105050085983,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Architecture Studio Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mimarlık Fakültesi Stüdyoları Kantini"}}},
new MapSection {BuildingId=21,Latitude =35.1461797384021,Longitude =33.9082931349183,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Computer Engineering Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Bilgisayar Mühendisliği Kantini"}}},
new MapSection {BuildingId=22,Latitude =35.144487782992,Longitude =33.907790390213,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Electrical and Electronic Engineering Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Elektrik ve Elektronik Mühendisliği Kantini"}}},
new MapSection {BuildingId=7,Latitude =35.1430014061867,Longitude =33.9112590932541,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="CL Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kafe CL"}}},
new MapSection {BuildingId=23,Latitude =35.1414964630246,Longitude =33.908305728836,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="LMP Sport Building Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="LMP Spor Sarayı Kantini"}}},
new MapSection {BuildingId=24,Latitude =35.1435806989316,Longitude =33.9109790846558,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Cambo Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Cambo Kafe"}}},
new MapSection {BuildingId=81,Latitude =35.141488069631,Longitude =33.9112420552253,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosks Corn"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe Mısır Köşkü"}}},
new MapSection {BuildingId=73,Latitude =35.1409683297555,Longitude =33.9114502711639,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosks -F- (SULTAN)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -F- (SULTAN)"}}},
new MapSection {BuildingId=79,Latitude =35.1426024222371,Longitude =33.9098707374344,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosks -D- (KOZY)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -D- (KOZY)"}}},
new MapSection {BuildingId=80,Latitude =35.1424118610637,Longitude =33.9133074490737,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosks -E- (PERİ)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -E- (PERİ)"}}},
new MapSection {BuildingId=26,Latitude =35.1456693965551,Longitude =33.9071895595246,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Industrial Engineering Department Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Endüstri Mühendisliği Kafeteryası"}}},
new MapSection {BuildingId=46,Latitude =35.1389157970003,Longitude =33.9116026441802,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Hamurabi"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Hamurabi"}}},
new MapSection {BuildingId=27,Latitude =35.143594782992,Longitude =33.899611390213,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Medicine Canteen"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Tıp Fakültesi Kantini"}}},
new MapSection {BuildingId=23,Latitude =35.141847782992,Longitude =33.9081772711639,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="LMP Sports Building Vitamin Bar"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="LMP Spor Sarayı Vitamin Büfe"}}},
new MapSection {BuildingId=77,Latitude =35.1486294183391,Longitude =33.9060201018524,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosk -B- (EGEM)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -B- (EGEM)"}}},
new MapSection {BuildingId=76,Latitude =35.148591782992,Longitude =33.904052390213,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosk -A- (MATİA)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -A- (MATİA)"}}},
new MapSection {BuildingId=78,Latitude =35.1410629097648,Longitude =33.9015946527786,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosk -C-"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -C-"}}},
new MapSection {BuildingId=75,Latitude =35.1437989426066,Longitude =33.9074124576721,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wooden Snack Kiosk -G- (NEJLA TOPÇU)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ahşap Kulübe -G- (NEJLA TOPÇU)"}}},
new MapSection {BuildingId=69,Latitude =35.1465395664274,Longitude =33.9049806710643,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Basket Market"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Basket Market"}}},
new MapSection {BuildingId=7,Latitude =35.1427615749504,Longitude =33.9110150092624,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Break Point Coffee"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Break Point Coffee"}}},
new MapSection {BuildingId=51,Latitude =35.1435721216491,Longitude =33.9093151208317,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Mardo Campus Cafe & Patisserie"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mardo Kampüs Cafe & Pastanesi"}}},
new MapSection {BuildingId=33,Latitude =35.1433089283683,Longitude =33.9087759968204,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Financial Affairs and Students Affairs Kiosks"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mali İşler ve Öğrenci İşleri Büfesi"}}},
new MapSection {BuildingId=5,Latitude =35.1415708636072,Longitude =33.9003892625656,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Pharmacy and Faculty of Health Sciences Cafeteria"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Eczacılık Fakültesi ve Sağlık Bilimleri Fakültesi Kafeteryası"}}},
new MapSection {BuildingId=74,Latitude =35.144533,Longitude =33.9104575,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Hidden Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Hidden Kafe"}}},
new MapSection {BuildingId=56,Latitude =35.146676,Longitude =33.906788,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Fanatic Global"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Fanatic Global"}}},
new MapSection {BuildingId=85,Latitude =35.146764,Longitude =33.908318,CreatedDate =DateTime.Now,MapSectionCategoryId = Restaurants,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Yemen Cafe"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Yemen Kahvesi"}}},
new MapSection {BuildingId=83,Latitude =35.1472598712592,Longitude =33.9071613550185,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alfam Dormitory Block B"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Alfam Yurdu Blok B"}}},
new MapSection {BuildingId=59,Latitude =35.1473256663778,Longitude =33.9057102799416,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Longson Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Longson Yurdu"}}},
new MapSection {BuildingId=58,Latitude =35.147742368098,Longitude =33.906209170818,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alfam Dormitory Block A"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Alfam Yurdu Blok A"}}},
new MapSection {BuildingId=39,Latitude =35.148492425725,Longitude =33.90688508749,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU 2 Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ 2 Yurdu"}}},
new MapSection {BuildingId=63,Latitude =35.149922340996,Longitude =33.90612334013,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Akdeniz Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Akdeniz Yurdu"}}},
new MapSection {BuildingId=43,Latitude =35.1492073865393,Longitude =33.9038220047951,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU 3 Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ 3 Yurdu"}}},
new MapSection {BuildingId=61,Latitude =35.148110818322,Longitude =33.904208242893,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Marmara Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Marmara Yurdu"}}},
new MapSection {BuildingId=46,Latitude =35.1391622698095,Longitude =33.9114904403688,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU 1 Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ 1 Yurdu"}}},
new MapSection {BuildingId=13,Latitude =35.1396360411516,Longitude =33.9108011126516,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Sabancı Students Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sabancı Yurdu"}}},
new MapSection {BuildingId=44,Latitude =35.1488301687438,Longitude =33.9033231139183,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU 4 Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ 4 Yurdu"}}},
new MapSection {BuildingId=62,Latitude =35.1485889239384,Longitude =33.9054420590395,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Uğursal (Sanel) Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Uğursal (Sanel) Yurdu"}}},
new MapSection {BuildingId=60,Latitude =35.1468278149802,Longitude =33.9049109816553,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Kamacıoğlu Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kamacıoğlu Yurdu"}}},
new MapSection {BuildingId=90,Latitude =35.1658120085993,Longitude =33.9092266559603,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU Seaside Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ Deniz Erkek Yurdu"}}},
new MapSection {BuildingId=66,Latitude =35.1499740350044,Longitude =33.9051925655763,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="KYK Necmettin Erbakan Dormitory Block-1 (EMU -6- Dormitory)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="KYK Necmettin Erbakan Yurdu Blok 1 (DAÜ -5- Yurdu)"}}},
new MapSection {BuildingId=67,Latitude =35.151630529876,Longitude =33.9049114851501,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="HomeDorm Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="HomeDorm Yurdu"}}},
new MapSection {BuildingId=68,Latitude =35.151402451538,Longitude =33.9043106703308,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Ramen Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ramen Yurdu"}}},
new MapSection {BuildingId=41,Latitude =35.1504857456152,Longitude =33.9049651293304,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="KYK Necmettin Erbakan Dormitory Block-2 (EMU 6 Dormitory)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="KYK Necmettin Erbakan Yurdu Blok-2 (DAÜ 6 Yurdu)"}}},
new MapSection {BuildingId=92,Latitude =35.147798,Longitude =33.906179,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alfam Dormitory Block C"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Alfam Yurdu Blok C"}}},
new MapSection {BuildingId=84,Latitude =35.148107,Longitude =33.9072,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alfam Dormitory Studios"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Alfam Yurdu Stüdyolar"}}},
new MapSection {BuildingId=85,Latitude =35.146968,Longitude =33.908222,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alfam Vista Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Alfam Vista Yurdu"}}},
new MapSection {BuildingId=70,Latitude =35.150939,Longitude =33.905184,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Prime Living Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Prime Living Yurdu"}}},
new MapSection {BuildingId=95,Latitude =35.140079,Longitude =33.906366,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Golden Plus Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Golden Plus Yurdu"}}},
new MapSection {BuildingId=96,Latitude =35.140507,Longitude =33.915539,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Novel Centre Point Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Novel Centre Point Yurdu"}}},
new MapSection {BuildingId=113,Latitude =35.14052115,Longitude =33.90706349,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Astra Plus Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Astra Plus Yurdu"}}},
new MapSection {BuildingId=114,Latitude =35.139354,Longitude =33.907033,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Pop Art Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Pop Art Yurdu"}}},
new MapSection {BuildingId=115,Latitude =35.139477,Longitude =33.908007,CreatedDate =DateTime.Now,MapSectionCategoryId = Dormitories,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Nural Dormitory"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Nural Yurdu"}}},
new MapSection {BuildingId=51,Latitude =35.14344343457,Longitude =33.9089750318077,CreatedDate =DateTime.Now,MapSectionCategoryId = BanksAndAtms,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Koop Bank & ATM"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Koop Bank & ATM"}}},
new MapSection {BuildingId=48,Latitude =35.1418730331625,Longitude =33.9141919283419,CreatedDate =DateTime.Now,MapSectionCategoryId = BanksAndAtms,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Koop Bank & ATM"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Koop Bank & ATM"}}},
new MapSection {BuildingId=87,Latitude =35.146695,Longitude =33.908901,CreatedDate =DateTime.Now,MapSectionCategoryId = BanksAndAtms,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="ATM (Sağlık Merkezi)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="ATMs (Helath Center)"}}},
new MapSection {BuildingId=88,Latitude =35.144655,Longitude =33.912025,CreatedDate =DateTime.Now,MapSectionCategoryId = BanksAndAtms,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="ATM (Merkez)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="ATMs (Merkez)"}}},
new MapSection {BuildingId=2,Latitude =35.1403159859491,Longitude =33.9137890934948,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Auditor"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Murakıplık"}}},
new MapSection {BuildingId=10,Latitude =35.1410792721429,Longitude =33.9127215743069,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Social and Cultural Activities Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sosyal ve Kültürel Aktiviteler Müdürlüğü"}}},
new MapSection {BuildingId=30,Latitude =35.141421432455,Longitude =33.911890089512,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Özay Oral Library"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Özay Oral Kütüphanesi"}}},
new MapSection {BuildingId=31,Latitude =35.1429448428444,Longitude =33.909060310976,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Student Services Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Öğrenci Hizmetleri Ofisi"}}},
new MapSection {BuildingId=49,Latitude =35.140221671338,Longitude =33.910209685564,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Continuing Education Center"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sürekli Eğitim Merkezi"}}},
new MapSection {BuildingId=49,Latitude =35.1404739077637,Longitude =33.9098998904233,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU Employee\"s Cooperative"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ Çalışanları Kooperatifi"}}},
new MapSection {BuildingId=23,Latitude =35.141649538592,Longitude =33.9080196619029,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Lala Mustafa Paşa (LMP) Sports Complex"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Lala Mustafa Paşa (LMP) Spor Kompleksi"}}},
new MapSection {BuildingId=24,Latitude =35.1434941042427,Longitude =33.9108869433408,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Computer Center"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Bilgi İşlem Merkezi"}}},
new MapSection {BuildingId=14,Latitude =35.1420816228035,Longitude =33.9102559536692,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Alumni Communications and Career Development Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mezunlarla İletişim ve Kariyer Araştırma Müdürlüğü"}}},
new MapSection {BuildingId=32,Latitude =35.146514188634,Longitude =33.909358084202,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Health Center"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sağlık Merkezi"}}},
new MapSection {BuildingId=31,Latitude =35.1430457343389,Longitude =33.908904742853,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Registrar\"s Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Öğrenci İşleri Müdürlüğü"}}},
new MapSection {BuildingId=1,Latitude =35.1423711394853,Longitude =33.9087049663067,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="International Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Uluslararası Ofis"}}},
new MapSection {BuildingId=1,Latitude =35.1424248959744,Longitude =33.9090173153443,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Rector\"s Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Rektörlük"}}},
new MapSection {BuildingId=33,Latitude =35.1428834306947,Longitude =33.9085533734719,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Financial Affairs Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mali İşler Müdürlüğü"}}},
new MapSection {BuildingId=24,Latitude =35.1436344737811,Longitude =33.9107675850389,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Social Media Unit"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sosyal Medya Birimi"}}},
new MapSection {BuildingId=32,Latitude =35.1466688087042,Longitude =33.9092662185428,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Psychological Counseling, Guidance & Research Center (PDRAM)"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Psikolojik Danışmanlık, Rehberlik ve Araştırma Merkezi (PDRAM)"}}},
new MapSection {BuildingId=13,Latitude =35.139765606501,Longitude =33.910595875637,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Post Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Postane"}}},
new MapSection {BuildingId=52,Latitude =35.143908632261,Longitude =33.9110143482683,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Institute of Graduate Studies and Research"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Lisansüstü Eğitim Öğretim ve Araştırma Enstitüsü"}}},
new MapSection {BuildingId=33,Latitude =35.1432315806304,Longitude =33.9085280232437,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Personnel Affairs Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Personel İşleri Müdürlüğü"}}},
new MapSection {BuildingId=23,Latitude =35.1413437258569,Longitude =33.9078318592466,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Transportation Services Unit"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ulaşım İşleri Şube Amirliği"}}},
new MapSection {BuildingId=54,Latitude =35.1448738289136,Longitude =33.9050565497375,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU Stadium"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ Stadyumu"}}},
new MapSection {BuildingId=37,Latitude =35.148641337096,Longitude =33.9083313016441,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Church"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kilise"}}},
new MapSection {BuildingId=38,Latitude =35.1458867086044,Longitude =33.9040853647736,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Selim II. Mosque Islamic Cultural Center"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="II. Selim Camii İslami Kültür Merkezi"}}},
new MapSection {BuildingId=39,Latitude =35.1485733497762,Longitude =33.906322327092,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU Dormitory Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Yurtlar ve Kafeteryalar Müdürlüğü"}}},
new MapSection {BuildingId=40,Latitude =35.1492005854745,Longitude =33.9050402311829,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Halide Edip Adıvar Guest House"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Halide Edip Adıvar Misafirhanesi"}}},
new MapSection {BuildingId=65,Latitude =35.1494506011536,Longitude =33.9050214557197,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Namık Kemal Guest House"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Namık Kemal Misafirhanesi"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="General Secretary\"s Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Genel Sekreterlik"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Printing Office Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Basımevi Müdürlüğü"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Environment Affairs Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Çevre İşleri Müdürlüğü"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Control Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kontrol Müdürlüğü"}}},
new MapSection {BuildingId=55,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Project Affairs Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Proje İşleri Müdürlüğü"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Purchasing and Inventory Control Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Satınalma ve Envanter Kontrol Müdürlüğü"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Cleaning Services Unit"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Temizlik İşleri Şube Amirliği"}}},
new MapSection {BuildingId=55,Latitude =35.14618,Longitude =33.906087,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Technical Affairs Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Teknik İşler Müdürlüğü"}}},
new MapSection {BuildingId=2,Latitude =35.1403025,Longitude =33.9137875,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Canteens and Cafeterias Unit"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kantin ve Kafeteryalar Birimi"}}},
new MapSection {BuildingId=1,Latitude =35.14241,Longitude =33.908959,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Public Relations and Press Office Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Halkla İlişkiler ve Basın Müdürlüğü"}}},
new MapSection {BuildingId=1,Latitude =35.14241,Longitude =33.908959,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Promotion Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Tanıtım Ofisi"}}},
new MapSection {BuildingId=24,Latitude =35.143518,Longitude =33.9108735,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Web Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Web Ofisi"}}},
new MapSection {BuildingId=1,Latitude =35.14241,Longitude =33.908959,CreatedDate =DateTime.Now,MapSectionCategoryId = OfficesAndFacilties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Revolving Funds Directorate"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Döner Sermaye İşletme Müdürlüğü"}}},
new MapSection {BuildingId=18,Latitude =35.140754656979,Longitude =33.904165327549,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Foreign Languages and English Preparatory School"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Yabancı Diller ve İngilizce Hazırlık Okulu"}}},
new MapSection {BuildingId=4,Latitude =35.1441474723747,Longitude =33.9092244772461,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Law"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Hukuk Fakültesi"}}},
new MapSection {BuildingId=8,Latitude =35.1456915124428,Longitude =33.9097180037048,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Architecture"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mimarlık Fakültesi"}}},
new MapSection {BuildingId=26,Latitude =35.1454283258658,Longitude =33.9073120622185,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mühendislik Fakültesi"}}},
new MapSection {BuildingId=3,Latitude =35.1434149203926,Longitude =33.910291996434,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Arts & Sciences"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Fen ve Edebiyat Fakültesi"}}},
new MapSection {BuildingId=5,Latitude =35.1417348511268,Longitude =33.9008989004639,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Pharmacy"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Eczacılık Fakültesi"}}},
new MapSection {BuildingId=11,Latitude =35.1403662051018,Longitude =33.9121319918182,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Education"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Eğitim Fakültesi"}}},
new MapSection {BuildingId=6,Latitude =35.1435289708351,Longitude =33.9126737980392,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Communication and Media Studies"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İletişim Fakültesi"}}},
new MapSection {BuildingId=14,Latitude =35.1418313573498,Longitude =33.9104475645569,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Business & Economics"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İşletme ve Ekonomi Fakültesi"}}},
new MapSection {BuildingId=25,Latitude =35.1411821314638,Longitude =33.9005877642181,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Health Sciences"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sağlık Bilimleri Fakültesi"}}},
new MapSection {BuildingId=27,Latitude =35.1438316423885,Longitude =33.8993324903992,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Medicine"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Tıp Fakültesi"}}},
new MapSection {BuildingId=34,Latitude =35.1440114901698,Longitude =33.9114024309662,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Tourism"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Turizm Fakültesi"}}},
new MapSection {BuildingId=14,Latitude =35.1416953712754,Longitude =33.9103349117783,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="School of Business and Finance"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İşletme ve Finans Yüksekokulu"}}},
new MapSection {BuildingId=4,Latitude =35.14392595286,Longitude =33.9089401630905,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="School of Justice"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Adalet Meslek Yüksekokulu"}}},
new MapSection {BuildingId=20,Latitude =35.1418445172804,Longitude =33.9129393367317,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="School of Computing and Technology"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Bilgisayar ve Teknoloji Yüksekokulu"}}},
new MapSection {BuildingId=25,Latitude =35.1411119445714,Longitude =33.9008774427917,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="School of Health Services"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sağlık Hizmetleri Yüksekokulu"}}},
new MapSection {BuildingId=34,Latitude =35.1438623481355,Longitude =33.911547270253,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="School of Tourism and Hospitality Management"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Turizm ve Otelcilik Yüksekokulu"}}},
new MapSection {BuildingId=89,Latitude =35.143363,Longitude =33.9110115,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Modern Languages Division"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Modern Diller"}}},
new MapSection {BuildingId=112,Latitude =35.1404893,Longitude =33.9005591,CreatedDate =DateTime.Now,MapSectionCategoryId = SchoolsAndFaculties,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Faculty of Dentistry"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Dişçilik Fakültesi"}}},
new MapSection {BuildingId=8,Latitude =35.1456388751955,Longitude =33.9099754957703,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Architecture"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mimarlık Bölümü"}}},
new MapSection {BuildingId=8,Latitude =35.1454897361432,Longitude =33.9096375374344,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Interior Architecture"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İç Mimarlık Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1429587170244,Longitude =33.9099567203072,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Mathematics"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Matematik Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1430990875639,Longitude =33.9101739792374,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Arts, Humanities and Social Sciences"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sanat, Beşeri ve Sosyal Bilimler Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1435048447933,Longitude =33.9100050000694,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Biological Sciences"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Biyolojik Bilimler Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1432482309968,Longitude =33.9105173019913,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Translation and Interpretation"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mütercim Tercümanlık Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1433535085497,Longitude =33.909744825795,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Psychology"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Psikoloji Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1434829120218,Longitude =33.9105870394257,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Turkish Language and Literature"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Türk Dili ve Edebiyatı Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1436210883836,Longitude =33.9104475645569,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Physics"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Fizik Bölümü"}}},
new MapSection {BuildingId=3,Latitude =35.1436737269359,Longitude =33.9103563694504,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Chemistry"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kimya Bölümü"}}},
new MapSection {BuildingId=14,Latitude =35.1415310960694,Longitude =33.9107112586498,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Business Administration"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İşletme Bölümü"}}},
new MapSection {BuildingId=14,Latitude =35.1416407624976,Longitude =33.9102418720722,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Political Science and International Relations"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Siyaset Bilimi ve Uluslararası İlişkiler Bölümü"}}},
new MapSection {BuildingId=14,Latitude =35.1414170428274,Longitude =33.9105342328548,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Economics"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ekonomi Bölümü"}}},
new MapSection {BuildingId=14,Latitude =35.142050913629,Longitude =33.9102794229984,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Banking and Finance"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Bankacılık ve Finans Bölümü"}}},
new MapSection {BuildingId=6,Latitude =35.1434414641157,Longitude =33.9124010503292,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Radio-Tv and Film Studies - Journalism"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Radyo-Tv, Sinema ve Gazetecilik Bölümü"}}},
new MapSection {BuildingId=45,Latitude =35.1435818338227,Longitude =33.9079432189465,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Visual arts And Visual Communication Design"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Görsel Sanatlar ve Görsel İletişim Tasarımı Bölümü"}}},
new MapSection {BuildingId=6,Latitude =35.1435949934703,Longitude =33.9124144613743,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Public Relations and Advertising"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Halkla İlişkiler ve Reklamcılık Bölümü"}}},
new MapSection {BuildingId=21,Latitude =35.1460821286665,Longitude =33.9083522558212,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Computer Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Bilgisayar Mühendisliği Bölümü"}}},
new MapSection {BuildingId=22,Latitude =35.1447047827632,Longitude =33.9077165722846,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Electrical & Electronic Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Elektrik Elektronik Mühendisliği Bölümü"}}},
new MapSection {BuildingId=26,Latitude =35.145775079051,Longitude =33.9073088765144,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Industrial Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Endüstri Mühendisliği Bölümü"}}},
new MapSection {BuildingId=17,Latitude =35.1449899040513,Longitude =33.9088699221611,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Civil Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="İnşaat Mühendisliği Bölümü"}}},
new MapSection {BuildingId=16,Latitude =35.1428997225079,Longitude =33.9122454822063,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Mechanical Engineering"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Makine Mühendisliği Bölümü"}}},
new MapSection {BuildingId=25,Latitude =35.1414762628,Longitude =33.900113850832,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Nutrition and Dietetics"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Beslenme ve Diyetetik Bölümü"}}},
new MapSection {BuildingId=25,Latitude =35.1412678960391,Longitude =33.8999851047993,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Physiotherapy and Rehabilitation"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Fizyoterapi ve Rehabilitasyon Bölümü"}}},
new MapSection {BuildingId=25,Latitude =35.1410090818461,Longitude =33.9007951319218,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Nursing"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Hemşirelik Bölümü"}}},
new MapSection {BuildingId=25,Latitude =35.1412349959755,Longitude =33.9009238779545,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Health Management"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Sağlık Yönetimi Bölümü"}}},
new MapSection {BuildingId=25,Latitude =35.1412042892375,Longitude =33.9002104103565,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Department of Sports Sciences"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Spor Bilimleri Bölümü"}}},
new MapSection {BuildingId=50,Latitude =35.143274,Longitude =33.91183,CreatedDate =DateTime.Now,MapSectionCategoryId = Departments,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Fine Arts Education Department"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Güzel Sanatlar Eğitimi Bölümü"}}},
new MapSection {BuildingId=21,Latitude =35.1458869324252,Longitude =33.9083763957021,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - CMPE"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - CMPE"}}},
new MapSection {BuildingId=17,Latitude =35.1445709953443,Longitude =33.9085641503332,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - CE"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - CE"}}},
new MapSection {BuildingId=7,Latitude =35.1425115104526,Longitude =33.9106307923796,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - CL - Central Lecture Halls"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - CL - Merkezi Derslikler"}}},
new MapSection {BuildingId=16,Latitude =35.1427308408753,Longitude =33.9125525951386,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - ME"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - ME"}}},
new MapSection {BuildingId=50,Latitude =35.1432418771687,Longitude =33.9118216931815,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - MUS"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - MUS"}}},
new MapSection {BuildingId=20,Latitude =35.141866677512,Longitude =33.912623673677,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - CT"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - CT"}}},
new MapSection {BuildingId=35,Latitude =35.141384145813,Longitude =33.91035720706,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - RD"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - RD"}}},
new MapSection {BuildingId=14,Latitude =35.14181842447,Longitude =33.910515457392,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - BEA"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - BEA"}}},
new MapSection {BuildingId=34,Latitude =35.1442266549646,Longitude =33.9113737642768,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - TH"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - TH"}}},
new MapSection {BuildingId=3,Latitude =35.1435006839432,Longitude =33.9100165665149,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - AS"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - AS"}}},
new MapSection {BuildingId=11,Latitude =35.1406164758266,Longitude =33.9121703803537,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - EF"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - EF"}}},
new MapSection {BuildingId=22,Latitude =35.144742068457,Longitude =33.907358497381,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - EE"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - EE"}}},
new MapSection {BuildingId=26,Latitude =35.1455031198954,Longitude =33.9075462520125,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - IED"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - IED"}}},
new MapSection {BuildingId=4,Latitude =35.1442332346511,Longitude =33.9087666571145,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - LA"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - LA"}}},
new MapSection {BuildingId=18,Latitude =35.140859937719,Longitude =33.9042149484155,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - PREP"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - PREP"}}},
new MapSection {BuildingId=18,Latitude =35.1410507586557,Longitude =33.9033861458299,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - PREP2"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - PREP2"}}},
new MapSection {BuildingId=25,Latitude =35.1410441786061,Longitude =33.90104457736,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - SBF"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - SBF"}}},
new MapSection {BuildingId=6,Latitude =35.1437068517451,Longitude =33.9128711074593,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - FCMS"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - FCMS"}}},
new MapSection {BuildingId=45,Latitude =35.1435993815588,Longitude =33.9080424606802,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - CD"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - CD"}}},
new MapSection {BuildingId=5,Latitude =35.141612252063,Longitude =33.901438862085,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - PHAR"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - PHAR"}}},
new MapSection {BuildingId=30,Latitude =35.1412097757,Longitude =33.911850526929,CreatedDate =DateTime.Now,MapSectionCategoryId = Classes,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Classes - AUDIT"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Derslikler - AUDIT"}}},
new MapSection {BuildingId=7,Latitude =35.1427856731751,Longitude =33.9108976721764,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Book Store - Deniz Plaza"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kitap Satış - Deniz Plaza"}}},
new MapSection {BuildingId=91,Latitude =35.1674091739998,Longitude =33.9087843848415,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="EMU Beach Club"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="DAÜ Deniz Tesisleri"}}},
new MapSection {BuildingId=62,Latitude =35.148518,Longitude =33.9053265,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Barber"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Berber"}}},
new MapSection {BuildingId=62,Latitude =35.148518,Longitude =33.9053265,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Dry Cleaner"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Kuru Temizleme"}}},
new MapSection {BuildingId=57,Latitude =35.147178,Longitude =33.9087305,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Exchange Office"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Döviz Bürosu"}}},
new MapSection {BuildingId=93,Latitude =35.144671,Longitude =33.9062825,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Golf Course"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Golf Sahası"}}},
new MapSection {BuildingId=71,Latitude =35.139261,Longitude =33.912249,CreatedDate =DateTime.Now,MapSectionCategoryId = OtherImportantPlaces,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Sports Fields"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Spor Alanları"}}},
new MapSection {BuildingId=36,Latitude =35.165028279877,Longitude =33.905900668756,CreatedDate =DateTime.Now,MapSectionCategoryId = ActivityCentersAndHalls,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Rauf Raif Denktas Culture and Congress Center"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Rauf R. Denktaş Kültür ve Kongre Sarayı"}}},
new MapSection {BuildingId=7,Latitude =35.1424171989255,Longitude =33.9104738831519,CreatedDate =DateTime.Now,MapSectionCategoryId = ActivityCentersAndHalls,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Mustafa Afşin Ersoy Hall / CLA21"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mustafa Afşin Ersoy Salonu / CLA21"}}},
new MapSection {BuildingId=35,Latitude =35.14139072581,Longitude =33.910544961691,CreatedDate =DateTime.Now,MapSectionCategoryId = ActivityCentersAndHalls,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Prof. Dr. Mehmet Tahiroğlu Hall / Blue Hall"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Prof. Dr. Mehmet Tahiroğlu Salonu / Mavi Salon"}}},
new MapSection {BuildingId=10,Latitude =35.140857,Longitude =33.912642,CreatedDate =DateTime.Now,MapSectionCategoryId = ActivityCentersAndHalls,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Activity Hall"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Aktivite Salonu"}}},

new MapSection {BuildingId=98, CreatedDate = DateTime.Now, MapSectionCategoryId = StreetAddresses, MapSectionTranslation = new List<MapSectionTranslation> { new MapSectionTranslation { LanguageId = _englishLanguageId, LocationName = "William Shakespeare Street" }, new MapSectionTranslation { LanguageId = _turkishLanguageId, LocationName = "William Shakespeare Caddesi" } }},
new MapSection {BuildingId=99, CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Mimar Sinan Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Mimar Sinan Caddesi"}}},
new MapSection {BuildingId=106,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Charles Darwin Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Charles Darwin Caddesi"}}},
new MapSection {BuildingId=108,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Ludwig van Bethoven Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Ludwig van Bethoven Caddesi"}}},
new MapSection {BuildingId=107,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Adnan Saygun Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Adnan Saygun Caddesi"}}},
new MapSection {BuildingId=105,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Wolfgang Amadeus Mozart Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Wolfgang Amadeus Mozart Caddesi"}}},
new MapSection {BuildingId=109,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Leonardo da Vinci Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Leonardo da Vinci Caddesi"}}},
new MapSection {BuildingId=103,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Aristoteles Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Aristoteles Caddesi"}}},
new MapSection {BuildingId=110,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Jean-Jaques Rousseau Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Jean-Jaques Rousseau Caddesi"}}},
new MapSection {BuildingId=101,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Socrates Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Socrates Caddesi"}}},
new MapSection {BuildingId=102,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Pablo Picasso Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Pablo Picasso Caddesi"}}},
new MapSection {BuildingId=111,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Van Gogh Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Van Gogh Caddesi"}}},
new MapSection {BuildingId=100,CreatedDate =DateTime.Now,MapSectionCategoryId = StreetAddresses,MapSectionTranslation = new List<MapSectionTranslation>{new MapSectionTranslation{LanguageId = _englishLanguageId,LocationName ="Galileo Galilei Street"},new MapSectionTranslation{LanguageId = _turkishLanguageId,LocationName ="Galileo Galilei Caddesi"}}},


            };


            foreach(var mapSection in mapSections)
            {
                _mapSectionRepo.Insert(mapSection);
            }



        }




    }


}
