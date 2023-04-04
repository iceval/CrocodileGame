using CrocodileGame.BussinessLogic.Services;
using CrocodileGame.Domain.Abstractions;
using CrocodileGame.Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CrocodileGame.Tests
{
    public class TopicServiceTests
    {
        private Mock<ITopicRepository> _topicRepositoryMock;
        private TopicService _service;

        [SetUp]
        public void Setup()
        {
            _topicRepositoryMock = new Mock<ITopicRepository>();
            _service = new TopicService(_topicRepositoryMock.Object);
        }

        [Test]
        public void GetCards_ShouldReturnTrue()
        {
            // arrange
            _topicRepositoryMock
                .Setup(x => x.GetTopics())
                .Verifiable();

            // act
            _service.GetTopics();

            // assert
            _topicRepositoryMock.Verify(x => x.GetTopics(), Times.Once);
        }

        [Test]
        public void GetCardById_ShouldReturnTrue()
        {
            // arrange
            int id = 1;
            _topicRepositoryMock
                .Setup(x => x.GetTopicById(id))
                .Returns(
                    new Topic()
                    {
                        Id = id,
                        Cards = new List<Card> { new Card { Word = "monkey" } },
                        Name = "animals"
                    })
                .Verifiable();

            // act
            var result = _service.GetTopicById(id);

            // assert
            Assert.IsTrue(result.Id == id);
        }

        [Test]
        public void Add_ShouldReturnTrue()
        {
            // arrange
            var topic = new Topic()
            {
                Id = 5,
                Cards = null,
                Name = "animals"
            };

            _topicRepositoryMock
                .Setup(x => x.Add(topic))
                .Verifiable();

            // act
            _service.Add(topic);

            // assert
            _topicRepositoryMock.Verify(x => x.Add(topic), Times.Once);
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException()
        {
            // arrange
            Topic topic = null;

            _topicRepositoryMock
                .Setup(x => x.Add(topic))
                .Verifiable();
            // act

            // assert
            Assert.Throws<ArgumentNullException>(() => _service.Add(topic));
            _topicRepositoryMock.Verify(x => x.Add(topic), Times.Never);

        }

        [Test]
        public void Update_ShouldReturnTrue()
        {
            // arrange
            int topicId = 2;
            var topic = new Topic()
            {
                Id = 5,
                Cards = null,
                Name = "animals"
            };

            _topicRepositoryMock
                .Setup(x => x.Update(topicId, topic))
                .Verifiable();

            // act
            _service.Update(topicId, topic);

            // assert
            _topicRepositoryMock.Verify(x => x.Update(topicId, topic), Times.Once);
        }

        [Test]
        public void Update_ShouldThrowArgumentNullException()
        {
            // arrange
            int topicId = 2;
            Topic topic = null;

            _topicRepositoryMock
                .Setup(x => x.Update(topicId, topic))
                .Verifiable();

            // act

            // assert
            Assert.Throws<ArgumentNullException>(() => _service.Update(topicId, topic));
            _topicRepositoryMock.Verify(x => x.Update(topicId, topic), Times.Never);

        }

        [Test]
        public void Delete_ShouldReturnTrue()
        {
            // arrange
            int topicId = 1;
            _topicRepositoryMock
                .Setup(x => x.Delete(topicId))
                .Verifiable();

            // act
            _service.Delete(topicId);

            // assert
            _topicRepositoryMock.Verify(x => x.Delete(topicId), Times.Once);
        }
    }
}