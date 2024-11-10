using GlaTicket.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventControllerTest
    {

        private readonly EventController controller=new EventController();
     
        [Fact]
        public void GetById_ReturnsOk()
        {
            var id = 1;
            var result = controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }
        public void Get_ReturnsOk()
        {
            var result = controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }
        public void Put()
        {
            GlaTicket.Event e = new GlaTicket.Event();
            var result = controller.Put(-1,e);
            Assert.IsType<OkObjectResult>(result);
        }
        public void Delete_ReturnsOk()
        {
            var id = 1;
            var result = controller.Delete(id);
            Assert.IsType<OkObjectResult>(result);
        }

    }
}

