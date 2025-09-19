using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async void Create_RetursOkResult_WhenRequestIsValid()
    {
        //Arrange : Tan�mlama i�in kullan�r. Create metodunda controllerda kulland���m�z yap�lar� tan�mlar�z. Parametreleri vs.
        var mediatorMock = new Mock<IMediator>();
        CreateCarCommand createCarCommand = new("Toyota", "Corolla", 5000);
        MessageResponse response = new("Ara� ba�ar�yla kaydedildi.");
        CancellationToken cancellationToken = new();

        mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

        CarsController carsController = new(mediatorMock.Object);

        //Act : ��lemi yap�p sonucu de�i�kene atar�z.
        var result = await carsController.Create(createCarCommand, cancellationToken);

        //Asert : ikinci par�ada elde etti�imiz resultu kontrol ederiz.
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCarCommand, cancellationToken), Times.Once());
    }
}