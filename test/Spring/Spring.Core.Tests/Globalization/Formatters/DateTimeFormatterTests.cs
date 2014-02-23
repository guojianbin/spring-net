#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;

using NUnit.Framework;

namespace Spring.Globalization.Formatters
{
	/// <summary>
	/// Unit tests for DateTimeFormatter class.
	/// </summary>
    /// <author>Aleksandar Seovic</author>
    [TestFixture]
    public class DateTimeFormatterTests
	{
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatNullValue()
        {
            DateTimeFormatter fmt = new DateTimeFormatter("d");
            fmt.Format(null);
        }

        [Test]
        public void ParseNullOrEmptyValue()
        {
            DateTimeFormatter fmt = new DateTimeFormatter("d");
            Assert.AreEqual(DateTime.MinValue, fmt.Parse(null));
            Assert.IsTrue(fmt.Parse("") is DateTime);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FormatNonDate()
        {
            DateTimeFormatter fmt = new DateTimeFormatter("d");
            fmt.Format("not a date");
        }
#if !MONO
        [Test]
        public void FormatUsingDefaults()
        {
            DateTimeFormatter fmt = new DateTimeFormatter("d", "en-US");
            Assert.AreEqual("8/14/2004", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("8/24/1974", fmt.Format(new DateTime(1974, 8, 24)));
            
            fmt = new DateTimeFormatter("dd-MMM-yyyy", "en-US");
            Assert.AreEqual("14-Aug-2004", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("24-Aug-1974", fmt.Format(new DateTime(1974, 8, 24)));

            fmt = new DateTimeFormatter("D", CultureInfoUtils.SerbianLatinCultureName);
#if NET_4_0            
            Assert.AreEqual("14. avgust 2004.", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("24. avgust 1974.", fmt.Format(new DateTime(1974, 8, 24)));
#else
            Assert.AreEqual("14. avgust 2004", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("24. avgust 1974", fmt.Format(new DateTime(1974, 8, 24)));
#endif
            fmt = new DateTimeFormatter("dd-MMM-yyyy", CultureInfoUtils.SerbianCyrillicCultureName);
#if NET_4_0
            Assert.AreEqual("14-авг.-2004", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("24-авг.-1974", fmt.Format(new DateTime(1974, 8, 24)));
#else
            Assert.AreEqual("14-авг-2004", fmt.Format(new DateTime(2004, 8, 14)));
            Assert.AreEqual("24-авг-1974", fmt.Format(new DateTime(1974, 8, 24)));
#endif
        }

        [Test]
        public void ParseUsingDefaults()
        {
            DateTimeFormatter fmt = new DateTimeFormatter("d", "en-US");
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("8/14/2004"));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("8/24/1974"));
            
            fmt = new DateTimeFormatter("dd-MMM-yyyy", "en-US");
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("14-Aug-2004"));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("24-Aug-1974"));

            fmt = new DateTimeFormatter("D", CultureInfoUtils.SerbianLatinCultureName);
#if NET_4_0
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("14. avgust 2004."));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("24. avgust 1974."));
#else
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("14. avgust 2004"));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("24. avgust 1974"));
#endif

            fmt = new DateTimeFormatter("dd-MMM-yyyy", CultureInfoUtils.SerbianCyrillicCultureName);
#if NET_4_0
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("14-авг.-2004"));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("24-авг.-1974"));
#else
            Assert.AreEqual(new DateTime(2004, 8, 14), fmt.Parse("14-авг-2004"));
            Assert.AreEqual(new DateTime(1974, 8, 24), fmt.Parse("24-авг-1974"));
#endif
        }
#endif
    }
}
