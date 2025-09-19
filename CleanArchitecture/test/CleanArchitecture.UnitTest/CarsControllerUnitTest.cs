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
        //Arrange : Tanýmlama için kullanýr. Create metodunda controllerda kullandýðýmýz yapýlarý tanýmlarýz. Parametreleri vs.
        var mediatorMock = new Mock<IMediator>();
        CreateCarCommand createCarCommand = new("Toyota", "Corolla", 5000);
        MessageResponse response = new("Araç baþarýyla kaydedildi.");
        CancellationToken cancellationToken = new();

        mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

        CarsController carsController = new(mediatorMock.Object);

        //Act : Ýþlemi yapýp sonucu deðiþkene atarýz.
        var result = await carsController.Create(createCarCommand, cancellationToken);

        //Asert : ikinci parçada elde ettiðimiz resultu kontrol ederiz.
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCarCommand, cancellationToken), Times.Once());
    }
}