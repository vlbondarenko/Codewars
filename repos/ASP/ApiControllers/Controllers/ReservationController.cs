using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;

namespace ApiControllers.Controllers
{
    #region О контроллерах API
    /*Контроллер API - это контроллер MVC, который отвечает за предоставление доступа 
    * к данным в приложении, не инкапсулируя их в НТМL-разметку. 
    * Это позволяет извлекать или модифицировать данные в модели без необходимости 
    * в применении действий, предлагаемых обычными контроллерами, такими как контроллер Home 
    * в примере приложения. 
    * Основная предпосылка веб-службы REST связана с тем, чтобы заключать в себе характеристики НТГР,
    * поэтому методы запросов (также называемые командами) указывают серверу операцию, 
    * подлежащую выполнению, а URL запроса определяет один или большее число объектов данных, 
    * к которым операция будет применена. 
    * Тестирование контроллеров API (для тестирование нужно вводить команды в консоль диспетчера пакетов)
    * Invoke-RestMethod http://localhost:7000/api/reservation -Method GET - тестирование метода GET для получения всех объектов резерывций
    * Invoke-RestMethod http://localhost:7000/api/reservation/1 -Method GET - тестирование метода GET для получения 1-го объекта в репозитории
    * Invoke-RestMethod http://localhost:7000/api/reservation -Method POST -Body (@{clientName="Anne ";location="Meeting Room 4"} | ConvertTo-Json) -ContentType "application/json"  - добавление нового объекта в репозиторий
    * Invoke-RestMethod http://localhost:7000/api/reservation -Method PUT -Body (@{reservationid ="1";clientName="ВоЬ";location="Media Room"} | ConvertTo-Json) -ContentType "application/json"  - изменение значенийсвойств объекта с указанным reservationid
    * Invoke-RestMethod http://localhost:7000/api/reservation/2 -Method DELETE - удаление объетка из с ReservationId=2 из репозитория
    */
    #endregion

    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository repository;

        public ReservationController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() =>
            repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) =>
            repository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation res) =>
            repository.AddReservation(new Reservation { ClientName = res.ClientName, Location = res.Location });

        [HttpPut]
        public Reservation Put([FromBody] Reservation res) =>
            repository.UpdateReservation(res);

        [HttpDelete("{id}")]
        public void Delete(int id) =>
            repository.DeleteReservation(id);
    }
}
