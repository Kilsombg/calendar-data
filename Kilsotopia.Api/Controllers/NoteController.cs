﻿using Kilsotopia.Application.Days.Commands.CreateDayNote;
using Kilsotopia.Application.Days.Commands.DeleteDayNote;
using Kilsotopia.Application.Days.Commands.UpdateDayNote;
using Kilsotopia.Application.Days.Queries.GetNoteById;
using Kilsotopia.Application.Days.Queries.GetNotes;
using Kilsotopia.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kilsotopia.Api.Controllers
{
    [ApiController]
    public class NoteController : BaseController
    {
        public NoteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        public Task<NoteDto> GetNoteById(int id)
        {
            return Mediator.Send(new GetNoteByIdQuery() { NoteId = id });
        }


        [HttpGet()]
        public Task<IEnumerable<NoteDto>> GetAllNotes()
        {
            return Mediator.Send(new GetNotesQuery());
        }


        [HttpPost]
        public Task<int> CreateNote([FromBody] Note note)
        {
            return Mediator.Send(new CreateDayNote() { Date = note.Date, Notes = note.Notes });
        }

        [HttpPut("{id}")]
        public Task UpdateNote(int id, [FromBody] string notes)
        {
            return Mediator.Send(new UpdateDayNote() { Id = id, Notes = notes });
        }


        [HttpDelete("{id}")]
        public Task DeleteNote(int id)
        {
            return Mediator.Send(new DeleteDayNote() { Id = id });
        }
    }
}
