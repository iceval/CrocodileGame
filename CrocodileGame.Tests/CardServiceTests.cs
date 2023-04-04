using CrocodileGame.BussinessLogic.Services;
using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CrocodileGame.Tests
{
    public class CardServiceTests
    {
        private Mock<ICardRepository> _cardRepositoryMock;
        private CardService _service;

        [SetUp]
        public void Setup()
        {
            _cardRepositoryMock = new Mock<ICardRepository>();
            _service = new CardService(_cardRepositoryMock.Object);
        }

        [Test]
        public void GetCards_ShouldReturnTrue()
        {
            // arrange
            _cardRepositoryMock
                .Setup(x => x.GetCards())
                .Verifiable();

            // act
            _service.GetCards();

            // assert
            _cardRepositoryMock.Verify(x => x.GetCards(), Times.Once);
        }

        [Test]
        public void GetCardById_ShouldReturnTrue()
        {
            // arrange
            var id = 0;
            _cardRepositoryMock
                .Setup(x => x.GetCardById(id))
                .Returns(
                    new Card()
                    {
                        Id = id,
                        Topics = new List<Topic> { new Topic { Name = "animals" } },
                        Word = "monkey"
                    })
                .Verifiable();

            // act
            var result = _service.GetCardById(id);

            // assert
            Assert.IsTrue(result.Id == id);
        }

        [Test]
        public void Add_ShouldReturnTrue()
        {
            // arrange
            var topicId = 2;
            var card = new Card()
            {
                Id = 5,
                Topics = null,
                Word = "notebook"
            };

            _cardRepositoryMock
                .Setup(x => x.Add(topicId, card))
                .Verifiable();

            // act
            _service.Add(topicId,card);

            // assert
            _cardRepositoryMock.Verify(x => x.Add(topicId, card), Times.Once);
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException()
        {
            // arrange
            int topicId = 2;
            Card card = null;

            _cardRepositoryMock

                .Setup(x => x.Add(topicId, card))
                .Verifiable();
            // act

            // assert
            Assert.Throws<ArgumentNullException>(() => _service.Add(topicId, card));
            _cardRepositoryMock.Verify(x => x.Add(topicId, card), Times.Never);

        }

        [Test]
        public void Update_ShouldReturnTrue()
        {
            // arrange
            var topicId = 2;
            var card = new Card()
            {
                Id = 5,
                Topics = null,
                Word = "notebook"
            };

            _cardRepositoryMock
                .Setup(x => x.Update(topicId, card))
                .Verifiable();

            // act
            _service.Update(topicId, card);

            // assert
            _cardRepositoryMock.Verify(x => x.Update(topicId, card), Times.Once);
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException()
        {
            // arrange
            var topicId = 2;
            Card card = null;

            _cardRepositoryMock
                .Setup(x => x.Update(topicId, card))
                .Verifiable();

            // act

            // assert
            Assert.Throws<ArgumentNullException>(() => _service.Update(topicId, card));
            _cardRepositoryMock.Verify(x => x.Update(topicId, card), Times.Never);

        }

        [Test]
        public void Delete_ShouldReturnTrue()
        {
            // arrange
            var topicId = 1;
            var cardId = 1;
            _cardRepositoryMock
                .Setup(x => x.Delete(topicId, cardId))
                .Verifiable();

            // act
            _service.Delete(topicId, cardId);

            // assert
            _cardRepositoryMock.Verify(x => x.Delete(topicId, cardId), Times.Once);
        }
    }
}