using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rest_api;
using rest_api.models;
using System;
using System.Linq;

namespace rest_pai.mstest
{
    [TestClass]
    public class CtxTest
    {
        private readonly DbCtx _ctx;

        public CtxTest()
        {
            _ctx = new InMemoryDbContextFactory().GetDbContext();
            //_articleRepository = new ArticleRepository(_dbContext);
        }

        [TestMethod]
        public void test_to_database()
        {
            //test contact
            _ctx.Contact.Add(new Contact { FirstName = "alain", LastName = "dudu", Address = new Address { City = "BRX", Street = "rue louise" } });
            //var service = new BlogService(context);
            //service.Add("http://sample.com");
            _ctx.SaveChanges();
            Assert.AreEqual(1, _ctx.Contact.Count());
            Assert.AreEqual("alain", _ctx.Contact.Single().FirstName);

            //test entreprise
            _ctx.Entreprise.Add(new Entreprise { Name = "genesis", Tva="123345545" });
            _ctx.SaveChanges();
            Assert.AreEqual(1, _ctx.Entreprise.Count());
            Assert.AreEqual("genesis", _ctx.Entreprise.Single().Name);

            try
            {
                _ctx.Entreprise.Add(new Entreprise { Name = "genesis" });
                _ctx.SaveChanges();
                Assert.IsFalse(true);
            } catch (Exception ex)
            {
                Assert.IsTrue(true);
            }

          

        }

        [TestMethod]
        public void entreprise_with_entities()
        {
            //test entreprise with enti  ties
            Entreprise entreprise = new Entreprise { Name = "genesis", Tva = "123345545" };
            Entity central = new Entity { Address = new Address { City = "BRX", Street = "AS" }, isSiegeCentral = true };
            entreprise.Entities.Add(central);
            _ctx.Entreprise.Add(entreprise);
            _ctx.SaveChanges();
            Entreprise entreprise_saved = _ctx.Entreprise.First(e => e.EntrepriseId == entreprise.EntrepriseId);
            Assert.AreEqual(1, entreprise_saved.Entities.Count());
        }
       }
}
