using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Services;
using Domain.Interfaces;
using AutoMapper;
using Application.Xml;

namespace Application.UseCases;

public class ImportarNotaFiscalUseCase : INotaFiscalService
{
    private readonly INotaFiscalRepository _repository;
    private readonly NotaFiscalDomainService _domainService;
    private readonly NotaFiscalXmlParser _xmlParser;
    private readonly IMapper _mapper;

    public ImportarNotaFiscalUseCase(
        INotaFiscalRepository repository,
        NotaFiscalDomainService domainService,
        NotaFiscalXmlParser xmlParser,
        IMapper mapper)
    {
        _repository = repository;
        _domainService = domainService;
        _xmlParser = xmlParser;
        _mapper = mapper;
    }

    public async Task<Result<bool>> ImportarXmlAsync(string xmlContent)
    {
        try
        {
            var nota = _xmlParser.Parse(xmlContent);

            _domainService.Validate(nota);

            await _repository.AddAsync(nota);

            return Result<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Fail(ex.Message);
        }
    }

    public async Task<Result<IEnumerable<NotaFiscalDto>>> ObterNotasAsync()
    {
        try
        {
            var notas = await _repository.GetAllAsync();

            var mapped = _mapper.Map<IEnumerable<NotaFiscalDto>>(notas);

            return Result<IEnumerable<NotaFiscalDto>>.Ok(mapped);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<NotaFiscalDto>>.Fail(ex.Message);
        }
    }
}
