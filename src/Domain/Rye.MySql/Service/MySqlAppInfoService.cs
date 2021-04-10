﻿using Dapper;

using Rye.Cache;
using Rye.Cache.Store;
using Rye.Entities.Abstractions;
using Rye.Enums;

using System.Threading.Tasks;

namespace Rye.MySql.Service
{
    public class MySqlAppInfoService : IAppInfoService
    {
        private readonly MySqlConnectionProvider _connectionProvider;
        private readonly ICacheStore _store;

        public MySqlAppInfoService(MySqlConnectionProvider connectionProvider, ICacheStore store)
        {
            _connectionProvider = connectionProvider;
            _store = store;
        }

        public string GetAppSecret(string appKey)
        {
            var entry = CacheEntryCollection.GetAppSecretEntry(appKey);
            var appSecret = _store.Get<string>(entry);
            if (!appSecret.IsNullOrEmpty())
                return appSecret;

            var sql = "select `appSecret` from `appInfo` where appKey = @appKey and status = @status limit 1";
            var parameter = new DynamicParameters();
            parameter.Add("@appKey", appKey);
            parameter.Add("@status", (int)EntityStatus.Enabled);
            using (var conn = _connectionProvider.GetReadOnlyConnection())
            {
                appSecret = conn.Connection.QueryFirstOrDefault<string>(sql, param: parameter);
            }

            if (!appSecret.IsNullOrEmpty())
                _store.Set(entry, appSecret);
            return appSecret;
        }

        public async Task<string> GetAppSecretAsync(string appKey)
        {
            var entry = CacheEntryCollection.GetAppSecretEntry(appKey);
            var appSecret = await _store.GetAsync<string>(entry);
            if (!appSecret.IsNullOrEmpty())
                return appSecret;

            var sql = "select `appSecret` from `appInfo` where appKey = @appKey and status = @status limit 1";
            var parameter = new DynamicParameters();
            parameter.Add("@appKey", appKey);
            parameter.Add("@status", (int)EntityStatus.Enabled);
            using (var conn = _connectionProvider.GetReadOnlyConnection())
            {
                appSecret = await conn.Connection.QueryFirstOrDefaultAsync<string>(sql, param: parameter);
            }

            if (!appSecret.IsNullOrEmpty())
                await _store.SetAsync(entry, appSecret);
            return appSecret;
        }
    }
}