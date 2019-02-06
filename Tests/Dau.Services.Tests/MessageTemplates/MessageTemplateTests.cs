using Dau.Core.Domain.ContentManagement;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Dau.Services.MessageTemplates;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static Dau.Services.MessageTemplates.MessageTemplateService;

namespace Dau.Services.Tests.MessageTemplates
{
    [TestFixture]
    public class MessageTemplateTests
    {
        private Mock<IRepository<MessageTemplate>> _messageTemplateRepo;
        private Mock<IRepository<MessageTemplateTranslation>> _messageTemplateTransRepo;
        private Mock<ILanguageService> _languageService;
        private MessageTemplateService _messageTemplateService;

        [SetUp]
        public void SetUp()
        {

            _messageTemplateRepo = new Mock<IRepository<MessageTemplate>>();
            _messageTemplateTransRepo = new Mock<IRepository<MessageTemplateTranslation>>();
            _languageService = new Mock<ILanguageService>();

            _messageTemplateService = new MessageTemplateService(
                _messageTemplateRepo.Object,
                _messageTemplateTransRepo.Object,
                _languageService.Object
                );

        }



        [Test]
        public void MessageTemplates_Tokens_Replace_Tokenizer_test()
        {
            var tokens =
                new List<Tokens>
                {
                    new Tokens {TokenName ="%User.Firstname%", TokenValue="John" },
                    new Tokens {TokenName ="%User.LastName%", TokenValue="Doe"}
                };

            var template = "Firstname: %User.Firstname% <br> lastname: %User.LastName%<br>";
            var expected = "Firstname: John <br> lastname: Doe<br>";

            var result= _messageTemplateService.Tokenizer(template, tokens);

            Assert.AreEqual(expected, result);


        }


        [Test]
        public void MessageTemplates_Tokens_Replace_with_SpaceBetWeen_Token_InTemplate_Tokenizer_test()
        {
            var tokens =
                new List<Tokens>
                {
                    new Tokens {TokenName ="%User.Firstname%", TokenValue="John" },
                    new Tokens {TokenName ="%User.LastName%", TokenValue="Doe"}
                };

            var template = "Firstname: %User. Firstname% <br> lastname: %User.LastName%<br>";
            var expected = "Firstname: %User. Firstname% <br> lastname: Doe<br>";

            var result = _messageTemplateService.Tokenizer(template, tokens);

            Assert.AreEqual( expected, result);


        }


        [Test]
        public void MessageTemplates_Tokens_Replace_Token_Not_available_Tokenizer_test()
        {
            var tokens =
                new List<Tokens>
                {
                    new Tokens {TokenName ="%User.LastName%", TokenValue="Doe"}
                };

            var template = "Firstname: %User.Firstname% <br> lastname: %User.LastName%<br>";
            var expected = "Firstname: %User.Firstname% <br> lastname: Doe<br>";

            var result = _messageTemplateService.Tokenizer(template, tokens);

            Assert.AreEqual(expected, result);


        }

        [Test]
        public void MessageTemplates_Tokens_Token_Value_Blank_Replace_Tokenizer_test()
        {
            var tokens =
                new List<Tokens>
                {
                    new Tokens {TokenName ="%User.Firstname%", TokenValue="" },
                    new Tokens {TokenName ="%User.LastName%", TokenValue="Doe"}
                };

            var template = "Firstname: %User.Firstname% <br> lastname: %User.LastName%<br>";
            var expected = "Firstname:  <br> lastname: Doe<br>";

            var result = _messageTemplateService.Tokenizer(template, tokens);

            Assert.AreEqual(expected, result);


        }


        [Test]
        public void Parse_Tokens_To_Comma_Seperated_String()
        {
            var tokens =
                new List<Tokens>
                          {
                                new Tokens {TokenName="%User.Firstname%", TokenValue="" },
                                new Tokens {TokenName="%User.LastName%", TokenValue=""},
                                new Tokens {TokenName="%User.Verificationlink%", TokenValue=""}
                          };

            var expected = "%User.Firstname%, %User.LastName%, %User.Verificationlink%";

            var result = _messageTemplateService.StringToKens(tokens);

            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Parse_Tokens_To_Comma_Seperated_Tokens_equal_empty_String()
        {
            var tokens = new List<Tokens>();

            var expected = "";

            var result = _messageTemplateService.StringToKens(tokens);

            Assert.AreEqual(expected, result);
        }

    }
}
