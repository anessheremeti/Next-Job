using HelloWorld.Data;
using HelloWorld.Controllers;
using HelloWorld.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class ClientService : IClientService
{
    private readonly DataDapper _dataDapper;

    public ClientService(DataDapper dataDapper)
    {
        _dataDapper = dataDapper;
    }

    public async Task<IEnumerable<ClientProfile>> GetClientProfilesAsync()
    {
        try
        {
            var sql = "SELECT * FROM ClientProfiles";
            return await LoadDataFromDatabase<ClientProfile>(sql);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while retrieving client profiles: {ex.Message}", ex);
        }
    }

    public async Task<ClientProfile?> GetClientProfileByIdAsync(int id)
    {
        try
        {
            var sql = "SELECT * FROM ClientProfiles WHERE Id = @Id";
            var parameters = new { Id = id };
            var clientProfile = await LoadDataSingleFromDatabase<ClientProfile>(sql, parameters);

            if (clientProfile == null)
            {
                throw new Exception($"Client profile with ID {id} not found.");
            }

            return clientProfile;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while retrieving client profile with ID {id}: {ex.Message}", ex);
        }
    }


    public async Task<bool> CreateClientProfileAsync(ClientProfile clientProfile)
    {
        try
        {
            ValidateClientProfile(clientProfile);
            var sql = @"INSERT INTO ClientProfiles (UserId, Image, Skills, JobSuccess, TotalJobs, TotalHours, InQueueService, Location, LastDelivery, MemberSince, Education, Gender, EnglishLevel)
                        VALUES (@UserId, @Image, @Skills, @JobSuccess, @TotalJobs, @TotalHours, @InQueueService, @Location, @LastDelivery, @MemberSince, @Education, @Gender, @EnglishLevel)";
            return await _dataDapper.ExecuteSqlAsync(sql, clientProfile);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while creating client profile: {ex.Message}", ex);
        }
    }

    public async Task<bool> UpdateClientProfileAsync(int id, ClientProfile clientProfile)
    {
        try
        {
            if (clientProfile == null || id != clientProfile.Id || !clientProfile.isValid())
            {
                throw new ArgumentException("Invalid client profile data.");
            }

            var sql = @"UPDATE ClientProfiles 
                        SET UserId = @UserId, Image = @Image, Skills = @Skills, JobSuccess = @JobSuccess, TotalJobs = @TotalJobs, TotalHours = @TotalHours, 
                            InQueueService = @InQueueService, Location = @Location, LastDelivery = @LastDelivery, MemberSince = @MemberSince, 
                            Education = @Education, Gender = @Gender, EnglishLevel = @EnglishLevel 
                        WHERE Id = @Id";
            clientProfile.Id = id;
            return await _dataDapper.ExecuteSqlAsync(sql, clientProfile);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while updating client profile with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<bool> DeleteClientProfileAsync(int id)
    {
        try
        {
            var sql = "DELETE FROM ClientProfiles WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataDapper.ExecuteSqlAsync(sql, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while deleting client profile with ID {id}: {ex.Message}", ex);
        }
    }

    // Metodë për të ngarkuar të dhëna nga databaza
    private async Task<IEnumerable<T>> LoadDataFromDatabase<T>(string sql, object? parameters = null)
    {
        return await _dataDapper.LoadDataAsync<T>(sql, parameters);
    }

    // Metodë për të ngarkuar një të dhënë të vetme nga databaza
    private async Task<T?> LoadDataSingleFromDatabase<T>(string sql, object parameters)
    {
        return await _dataDapper.LoadDataSingleAsync<T>(sql, parameters);
    }


    private void ValidateClientProfile(ClientProfile clientProfile)
    {
        if (clientProfile == null || !clientProfile.isValid())
        {
            throw new ArgumentException("Invalid client profile data.");
        }
    }
}
