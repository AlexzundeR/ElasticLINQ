﻿// Copyright (c) Tier 3 Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. 

using System;
using System.Collections.Generic;
using ElasticLinq.Utility;
using Xunit;

namespace ElasticLINQ.Test.Utility
{
    public class ArgumentTests
    {
        [Fact]
        public void EnsureNotNullThrowsArgumentNullExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Argument.EnsureNotNull("a", null));
        }

        [Fact]
        public void EnsureNotNullDoesNotThrowsWhenValueIsNotNull()
        {
            Assert.DoesNotThrow(() => Argument.EnsureNotNull("a", "b"));
        }

        [Fact]
        public void EnsureNotBlankThrowsArgumentExceptionWhenValueIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => Argument.EnsureNotBlank("a", "   "));
        }

        [Fact]
        public void EnsureNotBlankThrowsArgumentExceptionWhenValueIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() => Argument.EnsureNotBlank("a", String.Empty));
        }

        [Fact]
        public void EnsureNotBlankThrowsArgumentNullExceptionWhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Argument.EnsureNotBlank("a", null));
        }

        [Fact]
        public void EnsureNotBlankDoesNotThrowsWhenValueIsNotBlank()
        {
            Assert.DoesNotThrow(() => Argument.EnsureNotBlank("a", "b"));
        }

        [Fact]
        public void EnsureIsDefinedEnumThrowsArgumentOutOfRangeExceptionWhenValueIsNotDefinedEnum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Argument.EnsureIsDefinedEnum("a", ((TestEnum)9)));
        }

        [Fact]
        public void EnsureIsDefinedEnumDoesNotThrowWhenValueIsDefinedEnum()
        {
            Assert.DoesNotThrow(() => Argument.EnsureIsDefinedEnum("a", TestEnum.Two));
        }

        [Fact]
        public void EnsureIsAssignableThrowsArgumentExceptionWhenTypeIsNotAssignable()
        {
            Assert.Throws<ArgumentException>(() => Argument.EnsureIsAssignableFrom<List<object>>("a", typeof(List<int>)));
        }

        [Fact]
        public void EnsureIsAssignableDoesNotThrowWhenTypeIsAssignable()
        {
            Assert.DoesNotThrow(() => Argument.EnsureIsAssignableFrom<IEnumerable<object>>("a", typeof(List<object>)));
        }

        private enum TestEnum
        {
            Two = 2,
        }
    }
}