using Autofac.Extras.Moq;
using AutoFixture;
using Moq;
using NUnit.Framework;
using projectlufi.Databases;
using projectlufi.Models;
using projectlufi.Services;
using projectlufi.ViewModels.UrunVM.DisGiyimVM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]

    public class KabanViewModelTests
    {
        private Fixture _fixture;
        public KabanViewModelTests() => _fixture = new Fixture();

        [Test]
        public void KabanGiyimViewModel_WhenSuccessfull_IsEmpty()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewmodel = mock.Create<KabanViewModel>();

                viewmodel.Urunler.Any();
            }
        }

        [Test]
        public void CreatingKabanViewModel_WhenSuccessfull_UrunlerBirListemi()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewmodel = mock.Create<KabanViewModel>();
                viewmodel.Urunler.ToList();
            }
        }

        [Test]
        public void KabanlarınCagrilmasıBaşarısızOldugunda()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IListService>().Setup(v => v.GetListItems()).Throws(new System.Exception("Unexpected error"));

                var viewmodel = mock.Create<KabanViewModel>();
                
                mock.Mock<IDialogService>().Verify(d=>d.Alert(It.IsAny<string>()));

            }
        }

        [Test]
        public  void KabanUrunlerisayısıtesti()
        {
            using (var mock = AutoMock.GetLoose())
            {

                var urunler = _fixture.CreateMany<ListItemDatabase>(8);
                mock.Mock<IListService>().Setup(v => v.GetListItems()).Returns(Task.FromResult(urunler));

                var viewModel = mock.Create<KabanViewModel>();
       
                viewModel.Urunler.Count.Equals(urunler.Count());

            }
        }

        [Test]
        public  void sqliteayazılanürünlerintesti()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var video = _fixture.Create<ListItemDatabase>();
                mock.Mock<ListItemDatabase>().Setup(v => v.GetListsAsync()).Throws(new System.Exception("Unexpected error"));

                var viewModel = mock.Create<ListItemDatabase>();

                mock.Mock<IDialogService>().Verify(d => d.Alert(It.IsAny<string>()));

            }
        }



    }
}
