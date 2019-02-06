using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Tests.Domain
{
    [TestFixture]
    public class EntityEqualityTests
    {
        [Test]
        public void Two_transient_entities_should_not_be_equal()
        {

            var b1 = new Booking();
            var b2 = new Booking();

            Assert.AreNotEqual(b1, b2, "Different transient entities should not be equal");
        }

        [Test]
        public void Two_references_to_same_transient_entity_should_be_equal()
        {

            var b1 = new Booking();
            var b2 = b1;

            Assert.AreEqual(b1, b2, "Two references to the same transient entity should be equal");
        }

        [Test]
        public void Entities_with_different_id_should_not_be_equal()
        {

            var b1 = new Booking { Id = 2 };
            var b2 = new Booking { Id = 5 };

            Assert.AreNotEqual(b1, b2, "Entities with different ids should not be equal");
        }

        [Test]
        public void Entity_should_not_equal_transient_entity()
        {

            var b1 = new Booking { Id = 1 };
            var b2 = new Booking();

            Assert.AreNotEqual(b1, b2, "Entity and transient entity should not be equal");
        }

        [Test]
        public void Entities_with_same_id_but_different_type_should_not_be_equal()
        {
            var id = 10;
            var b1 = new Booking { Id = id };

            var d1 = new Dormitory { Id = id };

            Assert.AreNotEqual(b1, d1, "Entities of different types should not be equal, even if they have the same id");
        }

    }

}
