﻿using FluentAssertions;
using Markdown.TokenModels;
using NUnit.Framework;

namespace MarkdownTests
{
    [TestFixture]
    public class ItalicToken_Should
    {
        [Test]
        public void Create_SimpleItalicToken_ReturnsCorrectToken() =>
            GetNewItalicTokenAsHtml("_some_", 0).Should().Be("<em>some</em>");

        [Test]
        public void Create_ItalicTokenAfterStringToken_ReturnsCorrect() =>
            GetNewItalicTokenAsHtml("foo _some bar_", 4)
                .Should()
                .Be("<em>some bar</em>");

        [Test]
        public void Create_BoldTokenIntoItalicToken_ReturnsOnlyItalicToken() =>
            GetNewItalicTokenAsHtml("_some __beautiful__ text_", 0).Should().Be("<em>some __beautiful__ text</em>");

        [TestCase("_some")]
        [TestCase("some_")]
        [TestCase("_some _")]
        [TestCase("__")]
        public void Create_SomeIncorrectInputs_ReturnsNull(string rawToken) =>
            ItalicToken.Create(rawToken, 0).Should().BeNull();

        [TestCase("_some_", 0, 6)]
        [TestCase("foo _bar_", 4, 5)]
        [TestCase("some _wrapped_ text", 5, 9)]
        public void GetMdTokenLength_SomeItalicTokens_ReturnsCorrectInt(string rawToken, int startIndex, int expected) =>
            ItalicToken.Create(rawToken, startIndex).MdTokenLength.Should().Be(expected);

        private static string GetNewItalicTokenAsHtml(string input, int startIndex) =>
            ItalicToken.Create(input, startIndex).ToHtmlString();
    }
}