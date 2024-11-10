using GlaTicket.Controllers;
using GlaTicketCore.classes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventControllerTest
    {

        private readonly EventController controller;
        public EventControllerTest()
        {
            controller=new EventController(new FakeContext());
        }

        [Fact]
        public void Get_ReturnsOk()
        {
            var result = controller.Get();
            Assert.IsType<ActionResult<IEnumerable<Event>>>(result);
        }
        [Fact]
        public void GetById_ReturnsOk()
        {
            var id = 0;
            var result = controller.Get(id);
            Assert.IsType<ActionResult<Event>>(result);
        }
        [Fact]
        public void GetById_ReturnsNotFound()
        {
            var id = 1;
            var result = controller.Get(id);
            Assert.IsType<ActionResult<Event>>(result);
        }
        [Fact]
        public void Put_ReturnsNotFound()
        {
            Event e = new Event(-1, "rut", 50, true, 85);
            var result = controller.Put(-1,e);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void Delete_ReturnsOk()
        {
            var id = 0;
            var result = controller.Delete(id);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Delete_ReturnsNotFound()
        {
            var id = 1;
            var result = controller.Delete(id);
            Assert.IsType<NotFoundObjectResult>(result);
        }

      
    }
}

