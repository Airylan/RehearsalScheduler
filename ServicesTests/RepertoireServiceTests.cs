using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityInterfaces;
using ServiceInterfaces;

namespace ServicesTests
{
    [TestClass()]
    public class RepertoireServiceTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Repertoire = new Moq.Mock<IRepertoire>().Object;
            RepertoireService = new RepertoireService(Repertoire);
        }
        
        private IRepertoire Repertoire { get; set; }
        private IRepertoireService RepertoireService { get; set; }

        [TestMethod()]
        public void ItShouldAddASong()
        {
            var song = new Moq.Mock<ISong>();
        }

        [TestMethod]
        public void ItShouldRemoveASong()
        {

        }

        [TestMethod]
        public void ItShouldRetrieveASong()
        {

        }
    }
}