using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MeetingMinutes.Infrastructure.Persistence.Repositories;

internal class MeetingRepository(AppDbContext dbContext) : IMeetingRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public void AddMeetingDetails(MeetingMinutesDetails meetingMinutesDetails)
    {
        _dbContext.Add(meetingMinutesDetails);
    }

    public void AddMeetingMaster(MeetingMinutesMaster meetingMinutesMaster)
    {
        _dbContext.Add(meetingMinutesMaster);
    }

    
    public async Task<long> SaveMeetingMinutesMasterAsync(MeetingMinutesMaster entity)
    {
        var insertedId = new SqlParameter {
            ParameterName = "@InsertedId",
            SqlDbType = SqlDbType.BigInt,
            Direction = ParameterDirection.Output,
        };

        await _dbContext.Database.ExecuteSqlRawAsync(@"EXECUTE dbo.Meeting_Minutes_Master_Save_SP @Place, 
                                                        @ClientSide, @HostSide, @Agenda, @Discussion, @Decision, 
                                                        @Datetime, @CorporateCustomerId, @IndividualCustomerId, 
                                                        @InsertedId OUT",
                new SqlParameter("@Place", entity.Place),
                new SqlParameter("@ClientSide", entity.ClientSide),
                new SqlParameter("@HostSide", entity.HostSide),
                new SqlParameter("@Agenda", entity.Agenda),
                new SqlParameter("@Discussion", entity.Discussion),
                new SqlParameter("@Decision", entity.Decision),
                new SqlParameter("@Datetime", entity.Datetime is null ? DBNull.Value : entity.Datetime),
                new SqlParameter("@CorporateCustomerId", entity.CorporateCustomerId is null or 0 ? DBNull.Value : entity.CorporateCustomerId),
                new SqlParameter("@IndividualCustomerId", entity.IndividualCustomerId is null or 0 ? DBNull.Value : entity.IndividualCustomerId),
                insertedId);

        return Convert.ToInt64(insertedId.Value);
    }

    public async Task SaveMeetingMinutesDetailAsync(MeetingMinutesDetails entity)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(@"EXEC Meeting_Minutes_Details_Save_SP @Quantity, @Unit, @ProductServiceId, @MeetingMinutesId",
            new SqlParameter("@Quantity", entity.Quantity is null ? DBNull.Value : entity.Quantity),
            new SqlParameter("@Unit", entity.Unit is null ? DBNull.Value : entity.Unit),
            new SqlParameter("@ProductServiceId", entity.ProductServiceId),
            new SqlParameter("@MeetingMinutesId", entity.MeetingMinutesId)
        );
    }
}
