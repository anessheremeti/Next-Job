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
            var sql = "SELECT * FROM ClientProfile";
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
            var sql = "SELECT * FROM ClientProfile WHERE Id = @Id";
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

            var sql = @"INSERT INTO ClientProfile 
            (user_id, image, skills, job_success, total_jobs, total_hours, in_queue_service, location, last_delivery, member_since, education, gender, english_level)
            VALUES 
            (@UserId, @Image, @Skills, @JobSuccess, @TotalJobs, @TotalHours, @InQueueService, @Location, @LastDelivery, @MemberSince, @Education, @Gender, @EnglishLevel)";


            return await _dataDapper.ExecuteSqlAsync(sql, new
            {
                UserId = clientProfile.UserId,
                Image = clientProfile.Image,
                Skills = clientProfile.Skills,
                JobSuccess = clientProfile.JobSuccess,
                TotalJobs = clientProfile.TotalJobs,
                TotalHours = clientProfile.TotalHours,
                InQueueService = clientProfile.InQueueService,
                Location = clientProfile.Location,
                LastDelivery = clientProfile.LastDelivery,
                MemberSince = clientProfile.MemberSince,
                Education = clientProfile.Education,
                Gender = clientProfile.Gender,
                EnglishLevel = clientProfile.EnglishLevel
            });
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

            var sql = @"UPDATE ClientProfile 
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
            var sql = "DELETE FROM ClientProfile WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dataDapper.ExecuteSqlAsync(sql, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while deleting client profile with ID {id}: {ex.Message}", ex);
        }
    }

    private async Task<IEnumerable<T>> LoadDataFromDatabase<T>(string sql, object? parameters = null)
    {
        return await _dataDapper.LoadDataAsync<T>(sql, parameters);
    }

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
