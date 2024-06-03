﻿using AutoMapper;
using ConectaBairro.Application.Dtos;
using ConectaBairro.Domain.Models;
using ConectaBairro.Infrastructure.Repository;
using ConectaBairro.Infrastructure.UnityOfWork;

namespace ConectaBairro.Application.Services
{
    public sealed class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IUnitOfWork uow, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<Evento>> GetEventsAsync()
        {
            return await _eventRepository.GetEventsAsync();
        }

        public async Task<Evento> CreateEventAsync(CreateEventDto evento, int userId)
        {
            if (evento.DataInicio <= DateTime.Now.AddDays(7))
            {
                throw new Exception("A data do evento deve ser pelo menos 7 dias maior que a data atual");
            }

            Evento mappedEvent = _mapper.Map<Evento>(evento);
            mappedEvent.UserId = userId;

            //bool eventoExists = await _eventRepository.FindEventOnDate(mappedEvent);
            //if (eventoExists)
            //{
            //    throw new Exception("Já existe um evento com o mesmo nome na mesma data.");
            //}
            var a = await _eventRepository.CreateEventAsync(mappedEvent);
            //await _uow.Commit();

            return a;
        }
    }
}
