using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;
using ToDoListApp.Repository;

namespace ToDoListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository repository;
        private readonly IMapper mapper;

        public ToDoController(IToDoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await repository.GetAllTask();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {

            try
            {
                var response = await repository.GetTaskById(Id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("CreatrToDoList")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDTO Dto)
        {
            if (ModelState.IsValid)
            {
                var ItemModel = mapper.Map<TaskItem>(Dto);
                ItemModel = await repository.CreateTask(ItemModel);
                var regionDto = mapper.Map<TaskItem>(Dto);
                return CreatedAtAction(nameof(GetById), new { Id = ItemModel.Id }, ItemModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateTask([FromRoute] Guid Id, [FromBody] UpdateTaskDTO task)
        {

            if (ModelState.IsValid)
            {
                var ItemModel = mapper.Map<TaskItem>(task);
                ItemModel = await repository.UpdateTask(ItemModel, Id);
                if (ItemModel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<UpdateTaskDTO>(ItemModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteList([FromRoute] Guid Id)
        {
            try
            {
                var response = await repository.DeleteTaskById(Id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
