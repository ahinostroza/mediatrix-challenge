namespace SB.TechnicalChallenge.Application;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SB.TechnicalChallenge.Domain;
using SB.TechnicalChallenge.Infrastructure;

public class UpdateOrganismCommandHandler : IRequestHandler<UpdateOrganismCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _connectionString;
    public UpdateOrganismCommandHandler(IMapper mapper, IConfiguration configuration)
    {
        //_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = Path.Combine(AppContext.BaseDirectory, _configuration["ConnectionStrings:ConnectionEntity"]);
    }

    public async Task<bool> Handle(UpdateOrganismCommand request, CancellationToken cancellationToken)
    {
        #region Entity Framework
        //var organism = await _unitOfWork.Repository<Organism>().GetById(request.Id);

        //if (organism is null)
        //    throw new SBTechnicalChallengeException($"Organism with id : {request.Id} not found");

        //organism.Update(request.Name);

        //var strategy = _unitOfWork.CreateExecutionStrategy();

        //await strategy.ExecuteAsync(async () =>
        //{
        //    using (var transaction = await _unitOfWork.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            _unitOfWork.Repository<Organism>().Update(organism);
        //            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
        //            await transaction.CommitAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();
        //            throw new SBTechnicalChallengeException($"Database Error : {ex.Message}");
        //        }
        //    }
        //});
        #endregion

        #region Plain Text
        if (!File.Exists(_connectionString))
        {
            throw new FileNotFoundException(string.Format(BusinessExceptionMessages.FileNotExist, _connectionString));
        }

        var jsonData = await File.ReadAllTextAsync(_connectionString);
        var organisms = _mapper.Map<List<Organism>>(JsonConvert.DeserializeObject<List<OrganismViewModel>>(jsonData));
        var organism = organisms.FirstOrDefault(o => o.Id == request.Id);

        if (organism is null)
            throw new SBTechnicalChallengeException($"Organism with id : {request.Id} not found");

        organism.Update(request.Name);

        var serialize = JsonConvert.SerializeObject(_mapper.Map<List<OrganismViewModel>>(organisms), Formatting.Indented);
        await File.WriteAllTextAsync(_connectionString, serialize);
        #endregion

        return true;
    }
}
