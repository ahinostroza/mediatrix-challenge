namespace SB.TechnicalChallenge.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

public class OrganismQueryRepository : IOrganismQueryRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public OrganismQueryRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = Path.Combine(AppContext.BaseDirectory, _configuration["ConnectionStrings:ConnectionEntity"]);
    }

    public async Task<IEnumerable<OrganismViewModel>> GetAll(CancellationToken cancellationToken)
    {
        IEnumerable<OrganismViewModel> result;

        #region Dapper
        //using (var connection = new MySqlConnection(_connectionString))
        //{
        //    await connection.OpenAsync(cancellationToken);
        //    result = await connection.QueryAsync<OrganismViewModel>("sp_get_organism", commandType: CommandType.StoredProcedure);
        //}
        #endregion

        #region Plain Text
        if (!File.Exists(_connectionString))
        {
            throw new FileNotFoundException(string.Format(BusinessExceptionMessages.FileNotExist, _connectionString));
        }

        var jsonData = await File.ReadAllTextAsync(_connectionString);
        result = JsonSerializer.Deserialize<List<OrganismViewModel>>(jsonData).Where(m => m.IsActive);
        #endregion

        return result;
    }

    public async Task<OrganismViewModel> GetById(GetOrganismByIdQuery request, CancellationToken cancellationToken)
    {
        OrganismViewModel result;

        #region Dapper
        //var parameters = new DynamicParameters();
        //parameters.Add("@Id", request.Id);

        //using (var connection = new MySqlConnection(_connectionString))
        //{
        //    await connection.OpenAsync(cancellationToken);
        //    result = await connection.QueryFirstOrDefaultAsync<OrganismViewModel>("sp_get_organism_by_id", parameters, commandType: CommandType.StoredProcedure);
        //}
        #endregion

        #region Plain Text
        if (!File.Exists(_connectionString))
        {
            throw new FileNotFoundException(string.Format(BusinessExceptionMessages.FileNotExist, _connectionString));
        }

        var jsonData = await File.ReadAllTextAsync(_connectionString);
        var organisms = JsonSerializer.Deserialize<List<OrganismViewModel>>(jsonData);

        result = organisms.FirstOrDefault(x => x.Id == request.Id);
        #endregion

        return result;
    }

}
