﻿using System.Collections.Generic;
using Markdown.Core;

namespace Markdown.TokenModels
{
    public class BoldToken : IToken
    {
        private IEnumerable<IToken> Children { get; }
        public string ToHtmlString() => $"<strong>{Children.ConvertToHtmlString()}</strong>";
    }
}