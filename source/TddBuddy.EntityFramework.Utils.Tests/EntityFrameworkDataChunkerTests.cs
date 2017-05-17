using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

//todo right now this uses EVS domain and data to test, eventually it would be nice to move away from this and to have independenty test domain and entities
namespace EntityFramework.Utils.Tests
{
    [Category("Database")]
    [TestFixture]
    [SharedSpeedyLocalDb(typeof(EvsDbContext), typeof(DateTimeProvider.DateTimeProvider))]
    public class EntityFrameworkDataChunkerTests
    {
        [Test]
        public void Get_GivenNumberOfEntitiesOneLessThanOneChunk_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesEqualToOneChunk_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesOneMoreThanOneChunk_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesOneLessThanTwoChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 2 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesEqualToTwoChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 2;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesOneMoreThanTwoChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 2 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesOneLessThanThreeChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 3 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesEqualToThreeChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 3;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenNumberOfEntitiesOneMoreThanThreeChunks_ShouldReturnEntitiesInModifiedOrder()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 3 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                var expectedEntities = CreateEntities(createDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenCustomStartDate_ShouldReturnEntitiesModifiedOnOrAfterStartDate()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntities = chunkSize * 3;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var excludedEntitiesStartDate = DateTime.Now;
                var excludedEntitiesCreateDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, excludedEntitiesStartDate);
                CreateEntities(excludedEntitiesCreateDbContext, numberOfEntities);

                var includedEntitiesStartDate = excludedEntitiesStartDate.AddYears(1);
                var includedEntitiesCreateDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, includedEntitiesStartDate);
                var expectedEntities = CreateEntities(includedEntitiesCreateDbContext, numberOfEntities);

                var dataSource = CreateEntityFrameworkDataChunker(CreateEvsDbContext(wrapper), chunkSize, includedEntitiesStartDate);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().ToList();
                //---------------Test Result -----------------------
                CollectionAssert.AreEqual(IdsOf(expectedEntities), IdsOf(actualEntities));
            }
        }

        [Test]
        public void Get_GivenOneLessThanOneChunkOfEntitiesTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneChunkOfEntitiesTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneMoreThanOneChunkOfEntitiesTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneLessThanTwoChunksOfEntitiesTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 2 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenTwoChunksOfEntitiesTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 2;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneMoreThanTwoChunksOfEntitiesTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 2 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneLessThanThreeChunksOfEntitiesTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 3 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenThreeChunksOfEntitiesTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 3;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenOneMoreThanThreeChunksOfEntitiesTaken_ShouldLoadFourChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 3 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRollingDateTimes(wrapper, DateTime.Now);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var actualLoadedLoadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 4, actualLoadedLoadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossTwoChunks_ShouldCorrectlySplitEntitiesAcrossChunks()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 4;
            var numberOfEntitiesToTake = chunkSize * 3;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 10);
                var entities = CreateEntities(createDbContext, numberOfEntitiesToCreate);
                var estimatedFirstChunk = GetFirstChunk(entities, chunkSize);
                var estimatedSecondChunk = GetSecondChunk(entities, chunkSize);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                CollectionAssert.IsSubsetOf(IdsOf(estimatedFirstChunk), IdsOf(actualEntities));
                CollectionAssert.IsSubsetOf(IdsOf(estimatedSecondChunk), IdsOf(actualEntities));
                AssertNumberOfModifiedDates(8, actualEntities);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossTwoChunks_WhenOneLessThanOneChunkOfEntitiesIsTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 3;
            var numberOfEntitiesToTake = chunkSize - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 10);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossTwoChunks_WhenOneChunkOfEntitiesIsTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 3;
            var numberOfEntitiesToTake = chunkSize;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 10);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossTwoChunks_WhenOneMoreThanOneChunkOfEntitiesIsTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 5;
            var numberOfEntitiesToCreate = chunkSize * 3;
            var numberOfEntitiesToTake = chunkSize + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 10);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_ShouldCorrectlySplitEntitiesAcrossChunks()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 4;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                var entities = CreateEntities(createDbContext, numberOfEntitiesToCreate);
                var estimatedFirstChunk = GetFirstChunk(entities, chunkSize);
                var estimatedSecondChunk = GetSecondChunk(entities, chunkSize);
                var estimatedThirdChunk = GetThirdChunk(entities, chunkSize);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                var actualEntities = dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                CollectionAssert.IsSubsetOf(IdsOf(estimatedFirstChunk), IdsOf(actualEntities));
                CollectionAssert.IsSubsetOf(IdsOf(estimatedSecondChunk), IdsOf(actualEntities));
                CollectionAssert.IsSubsetOf(IdsOf(estimatedThirdChunk), IdsOf(actualEntities));
                AssertNumberOfModifiedDates(2, actualEntities);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneLessThanOneChunkOfEntitiesIsTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneChunkOfEntitiesIsTaken_ShouldLoadOneChunkFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneMoreThanOneChunkOfEntitiesIsTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneLessThanTwoChunksOfEntitiesIsTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 2 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenTwoChunksOfEntitiesIsTaken_ShouldLoadTwoChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 2;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 2, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneMoreThanTwoChunksOfEntitiesIsTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 2 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneLessThanThreeChunksOfEntitiesIsTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 3 - 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenThreeChunksOfEntitiesIsTaken_ShouldLoadThreeChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 3;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 3, loadedEntities.Count);
            }
        }

        [Test]
        public void Get_GivenEntitiesWithSameModifiedDateTimeSplitAcrossMultipleChunks_WhenOneMoreThanThreeChunksOfEntitiesIsTaken_ShouldLoadFourChunksFromDatabase()
        {
            //---------------Set up test pack-------------------
            var chunkSize = 2;
            var numberOfEntitiesToCreate = chunkSize * 5;
            var numberOfEntitiesToTake = chunkSize * 3 + 1;

            using (var wrapper = CreateSpeedyLocalDbWrapper())
            {
                var createDbContext = CreateEvsDbContextWithRepeatingDateTimes(wrapper, DateTime.Now, 20);
                CreateEntities(createDbContext, numberOfEntitiesToCreate);

                var repositoryContext = CreateEvsDbContext(wrapper);
                var loadedEntities = repositoryContext.RecordEntities<Request>();
                var dataSource = CreateEntityFrameworkDataChunker(repositoryContext, chunkSize);
                //---------------Execute Test ----------------------
                dataSource.Get().Take(numberOfEntitiesToTake).ToList();
                //---------------Test Result -----------------------
                Assert.AreEqual(chunkSize * 4, loadedEntities.Count);
            }
        }

        private static void AssertNumberOfModifiedDates(int expectedNumberOfModifiedDates, List<Request> actualEntities)
        {
            Assert.AreEqual(expectedNumberOfModifiedDates, actualEntities.GroupBy(entity => entity.Modified).Count());
        }

        private List<Request> GetFirstChunk(IEnumerable<Request> entities, int chunkSize)
        {
            return GetChunk(chunkSize, 1)(entities);
        }

        private List<Request> GetSecondChunk(IEnumerable<Request> entities, int chunkSize)
        {
            return GetChunk(chunkSize, 2)(entities);
        }

        private List<Request> GetThirdChunk(IEnumerable<Request> entities, int chunkSize)
        {
            return GetChunk(chunkSize, 3)(entities);
        }

        private Func<IEnumerable<Request>, List<Request>> GetChunk(int chunkSize, int chunkNumber)
        {
            return r => r.Skip(chunkSize*(chunkNumber - 1)).Take(chunkSize).ToList();
        }

        private List<Guid> IdsOf(IEnumerable<Request> entities)
        {
            return entities.Select(entity => entity.Id).ToList();
        }

        private List<Request> CreateEntities(EvsDbContext createDbContext, int numberOfEntities)
        {
            var governmentEntity = GovernmentEntityTestDataBuilder.Create()
                .WithRandomGroup()
                .WithRandomProps().Build();

            return createDbContext.CreateRequests(numberOfEntities, () => RequestBuilderTestDataFactory.Create(governmentEntity)
                .Build());
        }

        private EntityFrameworkDataChunker<Request> CreateEntityFrameworkDataChunker(EvsDbContext dbContext, int chunkSize)
        {
            return new EntityFrameworkDataChunker<Request>(() => dbContext.Requests, chunkSize);
        }

        private EntityFrameworkDataChunker<Request> CreateEntityFrameworkDataChunker(EvsDbContext dbContext, int chunkSize, DateTime startDateTime)
        {
            return new EntityFrameworkDataChunker<Request>(() => dbContext.Requests, chunkSize, startDateTime);
        }

        private EvsDbContext CreateEvsDbContext(ISpeedySqlLocalDbWrapper wrapper)
        {
            return EvsDbContextTestFactory.CreateEvsDbContext(wrapper.Connection);
        }

        private EvsDbContext CreateEvsDbContextWithRollingDateTimes(ISpeedySqlLocalDbWrapper wrapper, DateTime startDate)
        {
            return EvsDbContextTestFactory.CreateEvsDbContext(wrapper.Connection, new FakeRollingDateTimpeProvider(startDate));
        }

        private EvsDbContext CreateEvsDbContextWithRepeatingDateTimes(ISpeedySqlLocalDbWrapper wrapper, DateTime startDate, int multiple)
        {
            return EvsDbContextTestFactory.CreateEvsDbContext(wrapper.Connection, new FakeRepeatingDateTimpeProvider(startDate, 1, multiple));
        }

        private ISpeedySqlLocalDbWrapper CreateSpeedyLocalDbWrapper()
        {
            return new SpeedySqlFactory().CreateWrapper();
        }
    }
}