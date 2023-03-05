using AddressbookAPI.Controllers;
using Xunit;
using Moq;
using AddressbookAPI.Models;
using System.Collections.Generic;

namespace AddressbookAPITest
{
    public class ContactsControllerTest
    {
        private readonly ContactsController _sut;
        private readonly Mock<ContactRepository> _contactRepoMock = new Mock<ContactRepository>();

        public ContactsControllerTest()
        {
            _sut = new ContactsController(_contactRepoMock.Object);
        }
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void GetContacts_ReturnsAll()
        {
            //Arrange
            var contactlist = new List<Contact>
            {

            };
            _contactRepoMock.Setup(x => x.GetAllContacts()).Returns(contactlist);
            //Act
            var contact = _sut.GetContacts();

            //Assert
            Assert.NotNull(contact);
            //var controller = new ContactsController();
        }

        [Fact]
        public void Get_ReturnsAContact()
        {
            //Arrange
            var contactId = 0;
            var contactName = "Adam Mir";
            var contactEmail = "adammir97@gmail.com";
            var contactMobile = "+447503176461";
            var contactDetails = new Contact
            {
                Id = contactId,
                FullName= contactName,
                Email= contactEmail,
                Mobile= contactMobile
            };

            //TODO: fix this line
            _contactRepoMock.Setup(x => x.GetContactById(contactId)).Returns(contactDetails);

            //Act
            Contact contact = (Contact)_sut.Get(contactId);

            //Assert
            Assert.Equal(contactId, contact.Id);
            Assert.Equal(contactName, contact.FullName);
            Assert.Equal(contactEmail, contact.Email);
            Assert.Equal(contactMobile, contact.Mobile);
        }

        //TODO: More unit tests:
    }
}