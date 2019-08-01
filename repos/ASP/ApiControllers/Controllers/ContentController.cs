using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ContentController:Controller
    {
        [HttpGet("string")]     //параметр конструктора позволяет устанавливать тип формата данных для отправки клиенту
        public string GetString() => "This is a string response";

        [HttpGet("object")]
        /*Атрибут Produces - это фильтр, изменяющий тип содержимого объектов ObjectResult, 
         * которые используются инфраструктурой МVС "за кулисами" для представления 
         * результатов действий в контроллерах API. 
         * В аргументе атрибута указывается формат, который будет применяться для результата, 
         * возвращаемого действием, и допускается также указание дополнительных разрешенных типов. 
         * Атрибут Produces принудительно устанавливает формат, используемый ответом,*/
        [Produces("application/json")] 
        public Reservation GetObject() =>
            new Reservation
            {
                ReservationId = 100,
                ClientName = "Joe",
                Location = "Broad Room"
            };
    }
}
