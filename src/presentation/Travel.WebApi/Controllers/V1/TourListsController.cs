using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Application.TourLists.Commands.CreateTourList;
using Travel.Application.TourLists.Commands.DeleteTourList;
using Travel.Application.TourLists.Commands.UpdateTourList;
using Travel.Application.TourLists.Queries.ExportTours;
using Travel.Application.TourLists.Queries.GetTours;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourListsController : ApiController
    {
        
        // CQRS will be enforced in this class 
        private readonly IMediator _mediator;
      

        public TourListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ToursVm>> Get()
        {
            
            var getRequest = await _mediator.Send(new GetTourQuery());
            return Ok(getRequest);

        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await _mediator.Send(new ExportTourQueries { ListId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTourListCommand command)
        {
            return await _mediator.Send (command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTourListCommand command)
        {
            if (id != command.Id)
                return BadRequest();
      
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTourListCommand { Id = id });

            return NoContent();
        }
        
        
        /*
        private readonly TravelDbContext _context;

        public TourListsController(TravelDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourLists);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourList tourList)
        {
            await _context.TourLists.AddAsync(tourList);
            await _context.SaveChangesAsync();
            return Ok(tourList);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tourList = await
                _context.TourLists.SingleOrDefaultAsync(tp => tp.Id == id);
            
            if (tourList == null)
            {
                return NotFound();
            }
            _context.TourLists.Remove(tourList);
            await _context.SaveChangesAsync();
            return Ok(tourList);
        }*/

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
        // {
        //     _context.Update(tourList);
        //     await _context.SaveChangesAsync();
        //     return Ok(tourList);
        // }
        
    }
}