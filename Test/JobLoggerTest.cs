using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Belatrix.BusinessLayer;
using Belatrix.BusinessEntities;

namespace Test
{
    [TestFixture]
    class JobLoggerTest
    {
        [Test]
        public void TestLogInDataBaseInFileInConsoleMarkLogError()
        {
            
            JobLogger _JobLogger = new JobLogger(true, true, true, true, true, true);
            Result _Result=_JobLogger.LogMessage("Mensaje de prueba", false, false, true);

            if (_Result.Code==(int)Enumerates.Result.Success)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true);
            }            
            
        }

        [Test]
        public void TestDataBaseAndFile_MarkWarning()
        {

            JobLogger _JobLogger = new JobLogger(true, false, true, true, true, true);
            Result _Result = _JobLogger.LogMessage("Mensaje de prueba", false, true, false);

            Assert.NotNull(_Result);
            Assert.That(_Result.Code, Is.EqualTo((int)Enumerates.Result.Success));            

        }

        [Test]
        public void Test_WithOutMessage()
        {

            JobLogger _JobLogger = new JobLogger(true, false, true, true, true, true);
            Result _Result = _JobLogger.LogMessage("", false, true, false);

            Assert.NotNull(_Result);
            Assert.That(_Result.Code, Is.EqualTo((int)Enumerates.Result.Error));

        }

        [Test]
        public void Test_WithOutSetAnyRepository()
        {

            JobLogger _JobLogger = new JobLogger(false, false, false, true, true, true);
            Result _Result = _JobLogger.LogMessage("mensaje", false, true, false);

            Assert.NotNull(_Result);
            Assert.That(_Result.Code, Is.EqualTo((int)Enumerates.Result.Error));

        }

        [Test]
        public void Test_WithOutSetAnyMarker()
        {

            JobLogger _JobLogger = new JobLogger(true, true, true, false, false, false);
            Result _Result = _JobLogger.LogMessage("mensaje", false, true, false);

            Assert.NotNull(_Result);
            Assert.That(_Result.Code, Is.EqualTo((int)Enumerates.Result.Error));

        }

    }
}
