using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        var sql = @"
        SELECT 
            id AS Id,
            user_id AS UserId,
            image AS Image,
            skills AS Skills,
            job_success AS JobSuccess,
            total_jobs AS TotalJobs,
            total_hours AS TotalHours,
            in_queue_service AS InQueueService,
            location AS Location,
            last_delivery AS LastDelivery,
            member_since AS MemberSince,
            education AS Education,
            genderID AS GenderId,
            englishLevelID AS EnglishLevelId
        FROM ClientProfile";

        return await _dataDapper.LoadDataAsync<ClientProfile>(sql);
    }


    public async Task<ClientProfile?> GetClientProfileByIdAsync(int id)
    {
        var sql = @"
        SELECT 
            id AS Id,
            user_id AS UserId,
            image AS Image,
            skills AS Skills,
            job_success AS JobSuccess,
            total_jobs AS TotalJobs,
            total_hours AS TotalHours,
            in_queue_service AS InQueueService,
            location AS Location,
            last_delivery AS LastDelivery,
            member_since AS MemberSince,
            education AS Education,
            genderID AS GenderId,
            englishLevelID AS EnglishLevelId
        FROM ClientProfile
        WHERE id = @Id";

        return await _dataDapper.LoadDataSingleAsync<ClientProfile>(sql, new { Id = id });
    }

    public async Task<bool> CreateClientProfileAsync(ClientProfile clientProfile)
    {
        try
        {
            ValidateClientProfile(clientProfile);

            var sql = @"
                INSERT INTO ClientProfile 
                (user_id, image, skills, job_success, total_jobs, total_hours, in_queue_service, location, last_delivery, member_since, education, genderID, englishLevelID)
                VALUES 
                (@UserId, @Image, @Skills, @JobSuccess, @TotalJobs, @TotalHours, @InQueueService, @Location, @LastDelivery, @MemberSince, @Education, @GenderId, @EnglishLevelId)";

            return await _dataDapper.ExecuteSqlAsync(sql, new
            {
                clientProfile.UserId,
                clientProfile.Image,
                clientProfile.Skills,
                clientProfile.JobSuccess,
                clientProfile.TotalJobs,
                clientProfile.TotalHours,
                clientProfile.InQueueService,
                clientProfile.Location,
                clientProfile.LastDelivery,
                clientProfile.MemberSince,
                clientProfile.Education,
                clientProfile.GenderId,
                clientProfile.EnglishLevelId
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
            if (clientProfile == null || id != clientProfile.Id)
            {
                throw new ArgumentException("Invalid client profile ID or null profile.");
            }

            if (!clientProfile.IsValid(out string validationMessage))
            {
                throw new ArgumentException($"Invalid client profile data: {validationMessage}");
            }

            var sql = @"
                UPDATE ClientProfile 
                SET user_id = @UserId,
                    image = @Image,
                    skills = @Skills,
                    job_success = @JobSuccess,
                    total_jobs = @TotalJobs,
                    total_hours = @TotalHours,
                    in_queue_service = @InQueueService,
                    location = @Location,
                    last_delivery = @LastDelivery,
                    member_since = @MemberSince,
                    education = @Education,
                    genderID = @GenderId,
                    englishLevelID = @EnglishLevelId
                WHERE id = @Id";

            return await _dataDapper.ExecuteSqlAsync(sql, clientProfile);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while updating client profile with ID {id}: {ex.Message}", ex);
        }
    }

    public async Task<bool> DeleteClientProfileAsync(int id)
    {
        var sql = "DELETE FROM ClientProfile WHERE id = @Id";
        return await _dataDapper.ExecuteSqlAsync(sql, new { Id = id });
    }

    private void ValidateClientProfile(ClientProfile clientProfile)
    {
        if (clientProfile == null)
        {
            throw new ArgumentException("Client profile is null.");
        }

        if (!clientProfile.IsValid(out string validationMessage))
        {
            throw new ArgumentException($"Invalid client profile data: {validationMessage}");
        }
    }
}
