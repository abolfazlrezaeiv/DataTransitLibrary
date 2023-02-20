using System;
using DataTransitLibrary.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;

namespace DataTransitLibrary.Services
{
    public class RadisDataWriter : IDataWriter
    {
        public RadisDataWriter()
        {
        }

        public bool WriteData(List<string> data, string redisKey)
        {
            try
            {
                var redis = ConnectionMultiplexer.Connect(redisKey);

                var db = redis.GetDatabase();

                var redisValues = data.Select(x => (RedisValue)x).ToArray();

                db.ListRightPush(redisKey, redisValues);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
    }
}

