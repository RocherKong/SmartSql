﻿using SmartSql.Configuration.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartSql.Test.Unit.Tags
{
    public class IsNotEmptyTest : AbstractXmlConfigBuilderTest
    {
        [Fact]
        public void IsNotEmpty()
        {
            var msg = DbSession.ExecuteScalar<String>(new RequestContext
            {
                Scope = nameof(IsNotEmptyTest),
                SqlId = "IsNotEmpty",
                Request = new { UserName = "SmartSql" }
            });
            Assert.Equal("UserName IsNotEmpty", msg);
        }

        [Fact]
        public void GetEntity_IsNotEmpty()
        {
            var msg = DbSession.Query<Object>(new RequestContext
            {
                Scope = nameof(IsNotEmptyTest),
                SqlId = "GetEntity",
                Request = new { UserName = "SmartSql" }
            });
        }

        [Fact]
        public void IsNotEmpty_Required()
        {
            var msg = DbSession.ExecuteScalar<String>(new RequestContext
            {
                Scope = nameof(IsNotEmptyTest),
                SqlId = "IsNotEmpty_Required",
                Request = new { UserName = "SmartSql" }
            });
            Assert.Equal("UserName IsNotEmpty", msg);
        }
        [Fact]
        public void IsNotEmpty_Required_Fail()
        {
            try
            {
                var msg = DbSession.ExecuteScalar<String>(new RequestContext
                {
                    Scope = nameof(IsNotEmptyTest),
                    SqlId = "IsNotEmpty_Required",
                    Request = new { }
                });
                Assert.True(false);
            }
            catch (TagRequiredFailException ex)
            {
                Assert.True(true);
            }
        }
    }
}