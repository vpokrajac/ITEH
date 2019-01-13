﻿using NUnit.Framework;
using Store;


namespace StoreTests
{
    [TestFixture]
    public class SamplePageTests : BaseTest
    {
        private string _randomText;
        private const string Author = "Vlado";
        private const string Website = "http://store.demoqa.com";
        private const string ValidEmail = "vlado@gmail.com";


        [SetUp]
        public void GetRandomStringComment()
        {
            _randomText = Actions.GetRandomString(300);
        }

        [Test]
        [TestCase("invalidemail")]
        [TestCase("invalidimail@")]
        [TestCase("invalidemail@domain")]
        [TestCase("domain.com")]
        [TestCase("@domain.com")]
        [TestCase("@domain")]

        public void VerifyEmailFormatHasToBeCorrectToPostComment(string invalidEmail)
        {
            HomePage homePage = Utility.NavigateToPage<HomePage>();
            SamplePage samplePage = homePage.FooterMenu.ClickOnSamplePageLink();
            samplePage.CommentText = _randomText;
            samplePage.Author = Author;
            samplePage.Email = invalidEmail;
            samplePage.Website = Website;
            samplePage.ClickOnPostComment();
            CommentErrorPage commentErrorPage = Utility.GetThisPage<CommentErrorPage>();
            Assert.IsTrue(commentErrorPage.ErrorMessageIsCorrect());
            samplePage = commentErrorPage.ClickOnBack();
            samplePage.CommentText = _randomText;
            samplePage.Author = Author;
            samplePage.Email = ValidEmail;
            samplePage.Website = Website;
            samplePage.ClickOnPostComment();
            Assert.IsTrue(samplePage.CommentHasBeenPosted(Author, _randomText));
            Assert.IsTrue(samplePage.UrlContainsComment());

        }


    }
}
